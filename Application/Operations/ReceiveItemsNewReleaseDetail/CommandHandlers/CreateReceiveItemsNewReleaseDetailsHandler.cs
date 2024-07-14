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
    public class CreateReceiveItemsNewReleaseDetailHandler : IRequestHandler<CreateReceiveItemsNewReleaseDetail, Domain.Entities.ReceiveItemsNewReleaseDetail>
    {
        private readonly IReceiveItemsNewReleaseDetailRepository _receiveItemsNewReleaseDetailRepository;
        private readonly IItemManagementService _itemManagementService;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateReceiveItemsNewReleaseDetailHandler(
            IReceiveItemsNewReleaseDetailRepository receiveItemsNewReleaseDetailRepository,
            IItemManagementService itemManagementService,
            IMapper mapper)
        {
            _receiveItemsNewReleaseDetailRepository = receiveItemsNewReleaseDetailRepository;
            _mapper = mapper;
            _itemManagementService = itemManagementService;
        }

        async Task<Domain.Entities.ReceiveItemsNewReleaseDetail> IRequestHandler<CreateReceiveItemsNewReleaseDetail, Domain.Entities.ReceiveItemsNewReleaseDetail>.Handle(CreateReceiveItemsNewReleaseDetail request, CancellationToken cancellationToken)
        {

            var receiveItemsNewReleaseDetails = _mapper.Map<Domain.Entities.ReceiveItemsNewReleaseDetail>(request);

            // Check whether release qty > Qty
            await _itemManagementService.CheckReleaseQuantityAsync((int)request.Qty,(long)request.ReceiveItemsNewId);
            var result = await _receiveItemsNewReleaseDetailRepository.AddReceiveItemsNewReleaseDetail(receiveItemsNewReleaseDetails);

            // Update Released Qty in ReceiveItemsNew table
            await _itemManagementService.UpdateReleaseQuantityAsync((int)request.Qty, (long)request.ReceiveItemsNewId);

            return result;
        }
    }
}
