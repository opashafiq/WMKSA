using Application.Abstractions;
using Application.Operations.ItemService.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemService.CommandHandlers
{
    public class DeleteItemServiceHandler : IRequestHandler<DeleteItemService, Domain.Entities.ItemService>
    {
        private readonly IItemServiceRepository _itemServiceRepository;


        public DeleteItemServiceHandler(IItemServiceRepository itemServiceRepository)
        {
            _itemServiceRepository = itemServiceRepository;
        }

        async Task<Domain.Entities.ItemService> IRequestHandler<DeleteItemService, Domain.Entities.ItemService>.Handle(DeleteItemService request, CancellationToken cancellationToken)
        {
            return await _itemServiceRepository.DeleteItemService(request.Id);

        }
    }
}
