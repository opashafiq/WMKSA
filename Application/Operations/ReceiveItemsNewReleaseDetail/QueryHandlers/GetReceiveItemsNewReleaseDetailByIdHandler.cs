using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.ReceiveItemsNewReleaseDetail.Queries;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseDetails.QueryHandlers
{
    public class GetReceiveItemsNewReleaseDetailByIdHandler : IRequestHandler<GetReceiveItemsNewReleaseDetailById, ReceiveItemsNewReleaseDetailDto>
    {
        private readonly IReceiveItemsNewReleaseDetailRepository _receiveItemsNewReleaseDetailRepository;
        private readonly IReceiveItemsNewReleaseRepository _receiveItemsNewReleaseRepository;
        private readonly IJobOrderRepository _jobOrderRepository;
        public GetReceiveItemsNewReleaseDetailByIdHandler(
            IReceiveItemsNewReleaseDetailRepository receiveItemsNewReleaseDetailRepository,
            IReceiveItemsNewReleaseRepository receiveItemsNewReleaseRepository,
            IJobOrderRepository jobOrderRepository)
        {
            _receiveItemsNewReleaseDetailRepository = receiveItemsNewReleaseDetailRepository;
            _receiveItemsNewReleaseRepository = receiveItemsNewReleaseRepository;
            _jobOrderRepository = jobOrderRepository;
        }

        public async Task<ReceiveItemsNewReleaseDetailDto> Handle(GetReceiveItemsNewReleaseDetailById request, CancellationToken cancellationToken)
        {
            var receiveItemsNewReleaseDetail = await _receiveItemsNewReleaseDetailRepository.GetReceiveItemsNewReleaseDetailById(request.Id);
            
            ICollection<Domain.Entities.ReceiveItemsNewReleaseDetail> listReceiveItemsNewReleaseDetail = new HashSet<Domain.Entities.ReceiveItemsNewReleaseDetail>();
            listReceiveItemsNewReleaseDetail.Add(receiveItemsNewReleaseDetail);
            

            var finalReceiveItemsNewReleaseDetails =
                    (from rid in await _receiveItemsNewReleaseDetailRepository.GetAll()
                     join ri in await _receiveItemsNewReleaseRepository.GetAll()
                     on rid.ReceiveItemsNewReleaseId equals ri.Id
                     join jo in await _jobOrderRepository.GetAll()
                     on rid.JobOrderId equals jo.Id
                     select new ReceiveItemsNewReleaseDetailDto
                     {
                         Id = rid.Id,
                         ReceiveItemsNewReleaseId = rid.ReceiveItemsNewReleaseId,
                         Qty = rid.Qty,
                         JobOrderId = rid.JobOrderId,
                         JobOrderJobFIleNo = jo.JobFileNo,
                         JobOrderJobStatus = jo.JobStatus


                     }).ToList().FirstOrDefault();

            return finalReceiveItemsNewReleaseDetails;
        }
    }
}
