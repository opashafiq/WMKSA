using Application.Abstractions;
using Application.Operations.ItemService.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemService.QueryHandlers
{
    public class GetAllItemServiceHandler : IRequestHandler<GetAllItemService, ICollection<Domain.Entities.ItemService>>
    {
        private readonly IItemServiceRepository _itemServiceRepository;

        public GetAllItemServiceHandler(IItemServiceRepository itemServiceRepository)
        {
            _itemServiceRepository = itemServiceRepository;
        }

        public async Task<ICollection<Domain.Entities.ItemService>> Handle(GetAllItemService request, CancellationToken cancellationToken)
        {
            return await _itemServiceRepository.GetAll();
        }
    }
}
