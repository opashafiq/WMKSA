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
    public class GetItemServiceByIdHandler : IRequestHandler<GetItemServiceById, Domain.Entities.ItemService>
    {
        private readonly IItemServiceRepository _itemServiceRepository;

        public GetItemServiceByIdHandler(IItemServiceRepository itemServiceRepository)
        {
            _itemServiceRepository = itemServiceRepository;
        }

        public async Task<Domain.Entities.ItemService> Handle(GetItemServiceById request, CancellationToken cancellationToken)
        {
            return await _itemServiceRepository.GetItemServiceById(request.Id);
        }
    }
}
