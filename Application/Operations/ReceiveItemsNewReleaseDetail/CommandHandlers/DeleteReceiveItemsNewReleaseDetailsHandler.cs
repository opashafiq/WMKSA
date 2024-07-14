using Application.Abstractions;
using Application.Operations.ReceiveItemsNewReleaseDetail.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseDetail.CommandHandlers
{
    public class DeleteReceiveItemsNewReleaseDetailHandler : IRequestHandler<DeleteReceiveItemsNewReleaseDetail, Domain.Entities.ReceiveItemsNewReleaseDetail>
    {
        private readonly IReceiveItemsNewReleaseDetailRepository _receiveItemsNewReleaseDetailRepository;
        private readonly IItemManagementService _itemManagementService;

        public DeleteReceiveItemsNewReleaseDetailHandler(
            IReceiveItemsNewReleaseDetailRepository receiveItemsNewReleaseDetailRepository, IItemManagementService itemManagementService)
        {
            _receiveItemsNewReleaseDetailRepository = receiveItemsNewReleaseDetailRepository;
            _itemManagementService = itemManagementService;
        }

        async Task<Domain.Entities.ReceiveItemsNewReleaseDetail> IRequestHandler<DeleteReceiveItemsNewReleaseDetail, Domain.Entities.ReceiveItemsNewReleaseDetail>.Handle(DeleteReceiveItemsNewReleaseDetail request, CancellationToken cancellationToken)
        {
            //Subtract the qty from the ReleaseQty Column of ReceiveItemsNew Table
            var receiveItemsNewReleaseDetail = await _receiveItemsNewReleaseDetailRepository.GetReceiveItemsNewReleaseDetailById(request.Id); 
            await _itemManagementService.UpdateReleaseQuantityAsync((int)receiveItemsNewReleaseDetail.Qty*-1, (long)receiveItemsNewReleaseDetail.ReceiveItemsNewId);

            return await _receiveItemsNewReleaseDetailRepository.DeleteReceiveItemsNewReleaseDetail(request.Id);

        }
    }
}
