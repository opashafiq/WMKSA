using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.JobOrder.Commands;
using Application.Operations.JobOrder.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.JobOrder.QueryHandlers
{
    public class GetJobOrderByIdHandler : IRequestHandler<GetJobOrderById, Common.Dtos.JobOrderDto>
    {
        private readonly IJobOrderRepository _jobOrderRepository;
        private readonly ICustomerMasterRepository _customerMasterRepository;
        public GetJobOrderByIdHandler(
            IJobOrderRepository jobOrderRepository,
            ICustomerMasterRepository customerMasterRepository)
        {
            _jobOrderRepository = jobOrderRepository;
            _customerMasterRepository = customerMasterRepository;
        }

        public async Task<Common.Dtos.JobOrderDto> Handle(GetJobOrderById request, CancellationToken cancellationToken)
        {
            var jobOrder = await _jobOrderRepository.GetJobOrderById(request.Id);

            ICollection<Domain.Entities.JobOrder> listJobOrder = new HashSet<Domain.Entities.JobOrder>();
            listJobOrder.Add(jobOrder);
            var customerMaster = await _customerMasterRepository.GetAll();

            var finalJobOrderDto =
                    (from jo in listJobOrder
                     join cm in customerMaster
                     on jo.CustomerMasterId equals cm.Id
                     select new Common.Dtos.JobOrderDto
                     {
                         Id = jo.Id,
                         JobFileNo = jo.JobFileNo,
                         JobFileDate = jo.JobFileDate,
                         CustomerMasterId = jo.CustomerMasterId,
                         CustomerMasterCustCode = cm.CustCode,
                         CustomerMasterCustName = cm.CustName,
                         Service = jo.Service,
                         JobStatus = jo.JobStatus,
                         JobRefNo = jo.JobRefNo,
                         EntryBy = jo.EntryBy,
                         EntryDate = jo.EntryDate

                     }).ToList().FirstOrDefault();

            return finalJobOrderDto;
        }
    }
}
