using Application.Abstractions;
using Application.Operations.ItemsRateMaster.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMaster.QueryHandlers
{
    public class GetAllItemsRateMasterHandler : IRequestHandler<GetAllItemsRateMaster, ICollection<Domain.Entities.ItemsRateMaster>>
    {
        private readonly IItemsRateMasterRepository _itemsRateMasterRepository;

        public GetAllItemsRateMasterHandler(IItemsRateMasterRepository itemsRateMasterRepository)
        {
            _itemsRateMasterRepository = itemsRateMasterRepository;
        }

        public async Task<ICollection<Domain.Entities.ItemsRateMaster>> Handle(GetAllItemsRateMaster request, CancellationToken cancellationToken)
        {
            return await _itemsRateMasterRepository.GetAll();
        }
    }
}
