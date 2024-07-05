using Application.Abstractions;
using Application.Operations.JobOrder.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.JobOrder.CommandHandlers
{
    public class CreateJobOrderHandler : IRequestHandler<CreateJobOrder, Domain.Entities.JobOrder>
    {
        private readonly IJobOrderRepository _jobOrderRepository;
        private readonly ICustomerMasterRepository _customerMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateJobOrderHandler(IJobOrderRepository jobOrderRepository, 
            IMapper mapper,
            ICustomerMasterRepository customerMasterRepository)
        {
            _jobOrderRepository = jobOrderRepository;
            _mapper = mapper;
            _customerMasterRepository = customerMasterRepository;
        }



        async Task<Domain.Entities.JobOrder> IRequestHandler<CreateJobOrder, Domain.Entities.JobOrder>.Handle(CreateJobOrder request, CancellationToken cancellationToken)
        {
            // Get The task
            var jobOrdreCollectionTask = _jobOrderRepository.GetAll();
            // Await the task to get the collection
            var jobOrderCollection = await jobOrdreCollectionTask;
            // Calculate the new CustomerCode
            var newJObFileNoPrefix = GenerateNewJobFileNo(jobOrderCollection);
            

            var jobOrder = _mapper.Map<Domain.Entities.JobOrder>(request);
            jobOrder.JobStatus = 1;

            var datePrefix = jobOrder.JobFileDate?.ToString("ddMMyy") ?? "";
            var customerMaster = await _customerMasterRepository.GetCustomerMasterById(1); 

            if (customerMaster.CustName.Length == null)
            {
                jobOrder.JobFileNo = datePrefix + "-" + newJObFileNoPrefix;
            }
            else if (customerMaster.CustName.Length <= 2)
            {
                jobOrder.JobFileNo = customerMaster.CustName.ToUpper() + datePrefix + "-" + newJObFileNoPrefix;
            }
            else
            {
                jobOrder.JobFileNo = customerMaster.CustName.Substring(0, 3).ToUpper() + datePrefix + "-" + newJObFileNoPrefix;
            }

            return await _jobOrderRepository.AddJobOrder(jobOrder);
        }

        public static string GenerateNewJobFileNo(ICollection<Domain.Entities.JobOrder> collection)
        {
            // Fetch the maximum JobFIleNo, take rightmost 4 characters, convert to bigint, and add 1
            var maxJobFileNoSuffix = collection
                .Where(item => !string.IsNullOrEmpty(item.JobFileNo) && item.JobFileNo.Length >= 4)
                .Select(item => item.JobFileNo.Substring(item.JobFileNo.Length - 4))
                .Select(jobFileNoSuffix => long.TryParse(jobFileNoSuffix, out var result) ? result : 0)
                .DefaultIfEmpty(0)
                .Max() + 1;

            var newJobFileNoSuffix = maxJobFileNoSuffix.ToString().PadLeft(4, '0');
            //var newCustomerCode = "SUP" + newCustomerCodeSuffix;

            return newJobFileNoSuffix;
        }
    }
}
