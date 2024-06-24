using Application.Abstractions;
using Application.Operations.CustomerMaster.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.CustomerMaster.CommandHandlers
{
    public class CreateCustomerMasterHandler : IRequestHandler<CreateCustomerMaster, Domain.Entities.CustomerMaster>
    {
        private readonly ICustomerMasterRepository _customerMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateCustomerMasterHandler(ICustomerMasterRepository customerMasterRepository, IMapper mapper)
        {
            _customerMasterRepository = customerMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.CustomerMaster> IRequestHandler<CreateCustomerMaster, Domain.Entities.CustomerMaster>.Handle(CreateCustomerMaster request, CancellationToken cancellationToken)
        {
            // Get The task
            var customerMasterCollectionTask = _customerMasterRepository.GetAll();
            // Await the task to get the collection
            var customerMasterCollection = await customerMasterCollectionTask;
            // Calculate the new CustomerCode
            var newCustomerCodePrefix = GenerateNewCustomerCode(customerMasterCollection);

            var customerMaster = _mapper.Map<Domain.Entities.CustomerMaster>(request);

            if (customerMaster.CustName.Length == null)
            {
                customerMaster.CustCode = newCustomerCodePrefix;
            }
            else if (customerMaster.CustName.Length<=2)
            {
                customerMaster.CustCode = customerMaster.CustName.ToUpper() + newCustomerCodePrefix;
            }
            else
            {
                customerMaster.CustCode = customerMaster.CustName.Substring(0, 3).ToUpper() + newCustomerCodePrefix;
            }
            return await _customerMasterRepository.AddCustomerMaster(customerMaster);
        }

        public static string GenerateNewCustomerCode(ICollection<Domain.Entities.CustomerMaster> collection)
        {
            // Fetch the maximum CustomerCode, take rightmost 4 characters, convert to bigint, and add 1
            var maxCustomerCodeSuffix = collection
                .Where(item => !string.IsNullOrEmpty(item.CustCode) && item.CustCode.Length >= 4)
                .Select(item => item.CustCode.Substring(item.CustCode.Length - 4))
                .Select(vendorCodeSuffix => long.TryParse(vendorCodeSuffix, out var result) ? result : 0)
                .DefaultIfEmpty(0)
                .Max() + 1;

            var newCustomerCodeSuffix = maxCustomerCodeSuffix.ToString().PadLeft(4, '0');
            //var newCustomerCode = "SUP" + newCustomerCodeSuffix;

            return newCustomerCodeSuffix;
        }


    }
}
