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

namespace Application.Operations.ReceiveItemsNewReleaseDetail.QueryHandlers
{
    public class GetAllReceiveItemsNewReleaseDetailHandler : IRequestHandler<GetAllReceiveItemsNewReleaseDetail, ICollection<ReceiveItemsNewReleaseDetailDto>>
    {
        private readonly IReceiveItemsNewReleaseDetailRepository _receiveItemsNewReleaseDetailRepository;
        private readonly IReceiveItemsNewReleaseRepository _receiveItemsNewReleaseRepository;
        private readonly IReceiveItemsNewRepository _receiveItemsNewRepository;

        public GetAllReceiveItemsNewReleaseDetailHandler(
            IReceiveItemsNewReleaseDetailRepository receiveItemsNewReleaseDetailRepository,
            IReceiveItemsNewReleaseRepository receiveItemsNewReleaseRepository,
            IReceiveItemsNewRepository receiveItemsNewRepository
            )
        {
            _receiveItemsNewReleaseDetailRepository = receiveItemsNewReleaseDetailRepository;
            _receiveItemsNewReleaseRepository = receiveItemsNewReleaseRepository;
            _receiveItemsNewRepository = receiveItemsNewRepository;
        }

        public async Task<ICollection<ReceiveItemsNewReleaseDetailDto>> Handle(GetAllReceiveItemsNewReleaseDetail request, CancellationToken cancellationToken)
        {
            var t = await _receiveItemsNewReleaseDetailRepository.GetAll();
            var receiveItemsNewReleaseDetailDto =
                              (from rid in await _receiveItemsNewReleaseDetailRepository.GetAll()
                               join ri in await _receiveItemsNewReleaseRepository.GetAll()
                               on rid.ReceiveItemsNewReleaseId equals ri.Id                               
                               join rci in await _receiveItemsNewRepository.GetAll()
                               on rid.ReceiveItemsNewId equals rci.Id
                               select new ReceiveItemsNewReleaseDetailDto
                               {
                                   Id = rid.Id,
                                   ReceiveItemsNewReleaseId = rid.ReceiveItemsNewReleaseId,
                                   Qty=rid.Qty,
                                   ReceiveItemsNewId=rid.ReceiveItemsNewId,
                                   ReceiveItemsNewEIRNo=rci.Eirno
                                   

                               }).ToList();


            return receiveItemsNewReleaseDetailDto;
        }
    }
}
