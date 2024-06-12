using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.JobOrder.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.JobOrder.QueryHandlers
{
    public class GetAllJobOrderHandler : IRequestHandler<GetAllJobOrder, ICollection<Common.Dtos.JobOrderDto>>
    {
        private readonly IJobOrderRepository _jobOrderRepository;
        private readonly ICustomerMasterRepository _customerMasterRepository;

        public GetAllJobOrderHandler(
            IJobOrderRepository jobOrderRepository, ICustomerMasterRepository customerMasterRepository)
        {
            _jobOrderRepository = jobOrderRepository;
            _customerMasterRepository = customerMasterRepository;
        }

        public async Task<ICollection<Common.Dtos.JobOrderDto>> Handle(GetAllJobOrder request, CancellationToken cancellationToken)
        {
            var jobOrderDto =
                              (from jo in await _jobOrderRepository.GetAll()
                               join cm in await _customerMasterRepository.GetAll()
                               on jo.CustomerMasterId equals cm.Id
                               select new Common.Dtos.JobOrderDto
                               {
                                   Id = jo.Id,
                                   JobFileNo= jo.JobFileNo,
                                   JobFileDate= jo.JobFileDate,
                                   CustomerMasterId= jo.CustomerMasterId,
                                   CustomerMasterCustCode= cm.CustCode,
                                   CustomerMasterCustName= cm.CustName,
                                   Service= jo.Service,
                                   JobStatus= jo.JobStatus,
                                   JobRefNo = jo.JobRefNo,
                                   EntryBy= jo.EntryBy,
                                   EntryDate= jo.EntryDate
                               }).ToList<Common.Dtos.JobOrderDto>();

            return jobOrderDto;
        }
    }
}
