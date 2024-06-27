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
    public class GetAllItemsRateMasterHandler : IRequestHandler<GetAllItemsRateMaster, ICollection<ItemsRateMasterDto>>
    {
        private readonly IItemsRateMasterRepository _itemsRateMasterRepository;

        public GetAllItemsRateMasterHandler(IItemsRateMasterRepository itemsRateMasterRepository)
        {
            _itemsRateMasterRepository = itemsRateMasterRepository;
        }

        public async Task<ICollection<ItemsRateMasterDto>> Handle(GetAllItemsRateMaster request, CancellationToken cancellationToken)
        {
            var itemsRateMasterDto =
                                (from irm in await _itemsRateMasterRepository.GetAll()
                                 select new ItemsRateMasterDto
                                 {
                                    ItemsRateMasterId = irm.Id,
                                    RateCode = irm.RateCode,
                                    CustomerMasterId = irm.CustomerMasterId,
                                    EntryBy= irm.EntryBy,
                                    EntryDate = irm.EntryDate,

                                 }).ToList();


            return itemsRateMasterDto;
        }
    }
}
