using Application.Abstractions;
using Application.Operations.CustomerMaster.Commands;
using Application.Operations.Person.Commands;
using Application.Operations.SubCustomerMaster.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.SubCustomerMaster.CommandHandlers
{
    public class CreateSubCustomerMasterHandler : IRequestHandler<CreateSubCustomerMaster, Domain.Entities.SubCustomerMaster>
    {
        private readonly ISubCustomerMasterRepository _subCustomerMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateSubCustomerMasterHandler(ISubCustomerMasterRepository subCustomerMasterRepository, IMapper mapper)
        {  
            _subCustomerMasterRepository = subCustomerMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.SubCustomerMaster> IRequestHandler<CreateSubCustomerMaster, Domain.Entities.SubCustomerMaster>.Handle(CreateSubCustomerMaster request, CancellationToken cancellationToken)
        {
            // Get The task
            var subCustomerMasterCollectionTask = _subCustomerMasterRepository.GetAll();
            // Await the task to get the collection
            var subCustomerMasterCollection = await subCustomerMasterCollectionTask;
            // Calculate the new CustomerCode
            var newSubCustomerCodePrefix = GenerateNewSubCustomerCode(subCustomerMasterCollection);


            var subCustomerMaster = _mapper.Map<Domain.Entities.SubCustomerMaster>(request);

            if (subCustomerMaster.CustName.Length == null)
            {
                subCustomerMaster.CustCode = newSubCustomerCodePrefix;
            }
            else if (subCustomerMaster.CustName.Length <= 2)
            {
                subCustomerMaster.CustCode = subCustomerMaster.CustName.ToUpper() + newSubCustomerCodePrefix;
            }
            else
            {
                subCustomerMaster.CustCode = subCustomerMaster.CustName.Substring(0, 3).ToUpper() + newSubCustomerCodePrefix;
            }
            return await _subCustomerMasterRepository.AddSubCustomerMaster(subCustomerMaster);
        }

        public static string GenerateNewSubCustomerCode(ICollection<Domain.Entities.SubCustomerMaster> collection)
        {
            // Fetch the maximum CustomerCode, take rightmost 4 characters, convert to bigint, and add 1
            var maxSubCustomerCodeSuffix = collection
                .Where(item => !string.IsNullOrEmpty(item.CustCode) && item.CustCode.Length >= 4)
                .Select(item => item.CustCode.Substring(item.CustCode.Length - 4))
                .Select(vendorCodeSuffix => long.TryParse(vendorCodeSuffix, out var result) ? result : 0)
                .DefaultIfEmpty(0)
                .Max() + 1;

            var newSubCustomerCodeSuffix = maxSubCustomerCodeSuffix.ToString().PadLeft(4, '0');
            
            return newSubCustomerCodeSuffix;
        }
    }
}
