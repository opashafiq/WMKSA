using Application.Abstractions;
using Application.Operations.ItemService.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemService.CommandHandlers
{
    public class CreateItemServiceHandler : IRequestHandler<CreateItemService, Domain.Entities.ItemService>
    {
        private readonly IItemServiceRepository _itemServiceRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateItemServiceHandler(IItemServiceRepository itemServiceRepository, IMapper mapper)
        {
            _itemServiceRepository = itemServiceRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.ItemService> IRequestHandler<CreateItemService, Domain.Entities.ItemService>.Handle(CreateItemService request, CancellationToken cancellationToken)
        {

            var itemService = _mapper.Map<Domain.Entities.ItemService>(request);

            return await _itemServiceRepository.AddItemService(itemService);
        }
    }
}
