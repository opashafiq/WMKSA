using Application.Abstractions;
using Application.Operations.ReceiveItemsNewReleaseDetail.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseDetail.CommandHandlers
{
    public class UpdateReceiveItemsNewReleaseDetailHandler : IRequestHandler<UpdateReceiveItemsNewReleaseDetail, Domain.Entities.ReceiveItemsNewReleaseDetail>
    {
        private readonly IReceiveItemsNewReleaseDetailRepository _receiveItemsNewReleaseDetailRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;
        private readonly IItemManagementService _itemManagementService;

        public UpdateReceiveItemsNewReleaseDetailHandler(
            IReceiveItemsNewReleaseDetailRepository receiveItemsNewReleaseDetailRepository, IMapper mapper, 
            IItemManagementService itemManagementService)
        {
            _receiveItemsNewReleaseDetailRepository = receiveItemsNewReleaseDetailRepository;
            _mapper = mapper;
            _itemManagementService = itemManagementService;
        }

        async Task<Domain.Entities.ReceiveItemsNewReleaseDetail> IRequestHandler<UpdateReceiveItemsNewReleaseDetail, Domain.Entities.ReceiveItemsNewReleaseDetail>.Handle(UpdateReceiveItemsNewReleaseDetail request, CancellationToken cancellationToken)
        {

            var receiveItemsNewReleaseDetails = _mapper.Map<Domain.Entities.ReceiveItemsNewReleaseDetail>(request);

            // Calculate New Qty to be updated
            // Existing Release Qty - Existing Detail Qty + New Detail Qty
            var receiveItemsNewReleaseDetailsExisting = 
                await _receiveItemsNewReleaseDetailRepository
                .GetReceiveItemsNewReleaseDetailByIdAsNoTracking((int)receiveItemsNewReleaseDetails.Id);

            var NewQty = request.Qty - receiveItemsNewReleaseDetailsExisting.Qty; 

            // Check whether release qty > Qty
            await _itemManagementService.CheckReleaseQuantityAsync((int)NewQty, (long)request.ReceiveItemsNewId);

            var result = await _receiveItemsNewReleaseDetailRepository.UpdateReceiveItemsNewReleaseDetail(receiveItemsNewReleaseDetails);

            // Update Released Qty in ReceiveItemsNew table
            await _itemManagementService.UpdateReleaseQuantityAsync((int)NewQty, (long)request.ReceiveItemsNewId);

            return result;
        }
    }
}
