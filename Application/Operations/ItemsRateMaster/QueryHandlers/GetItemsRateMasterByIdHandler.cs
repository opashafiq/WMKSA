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
    public class GetItemsRateMasterByIdHandler : IRequestHandler<GetItemsRateMasterById, Domain.Entities.ItemsRateMaster>
    {
        private readonly IItemsRateMasterRepository _itemsRateMasterRepository;

        public GetItemsRateMasterByIdHandler(IItemsRateMasterRepository itemsRateMasterRepository)
        {
            _itemsRateMasterRepository = itemsRateMasterRepository;
        }

        public async Task<Domain.Entities.ItemsRateMaster> Handle(GetItemsRateMasterById request, CancellationToken cancellationToken)
        {
            return await _itemsRateMasterRepository.GetItemsRateMasterById(request.Id);
        }
    }
}
