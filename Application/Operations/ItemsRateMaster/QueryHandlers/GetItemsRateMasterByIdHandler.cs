using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.ItemsRateMaster.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMaster.QueryHandlers
{
    public class GetItemsRateMasterByIdHandler : IRequestHandler<GetItemsRateMasterById, ItemsRateMasterDto>
    {
        private readonly IItemsRateMasterRepository _itemsRateMasterRepository;

        public GetItemsRateMasterByIdHandler(IItemsRateMasterRepository itemsRateMasterRepository)
        {
            _itemsRateMasterRepository = itemsRateMasterRepository;
        }

        public async Task<ItemsRateMasterDto> Handle(GetItemsRateMasterById request, CancellationToken cancellationToken)
        {
            var itemsRateMaster = await _itemsRateMasterRepository.GetItemsRateMasterById(request.Id);
            ItemsRateMasterDto itemsRateMasterDto = new ItemsRateMasterDto
                {
                    ItemsRateMasterId = itemsRateMaster.Id,
                    RateCode = itemsRateMaster.RateCode,
                    CustomerMasterId = itemsRateMaster.CustomerMasterId,
                    EntryBy = itemsRateMaster.EntryBy,
                    EntryDate   = itemsRateMaster.EntryDate
                };
            return itemsRateMasterDto;
        }
    }
}
