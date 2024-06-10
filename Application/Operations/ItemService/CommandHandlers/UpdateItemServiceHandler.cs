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
    public class UpdateItemServiceHandler : IRequestHandler<UpdateItemService, Domain.Entities.ItemService>
    {
        private readonly IItemServiceRepository _itemServiceRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UpdateItemServiceHandler(IItemServiceRepository itemServiceRepository, IMapper mapper)
        {
            _itemServiceRepository = itemServiceRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.ItemService> IRequestHandler<UpdateItemService, Domain.Entities.ItemService>.Handle(UpdateItemService request, CancellationToken cancellationToken)
        {

            var itemService = _mapper.Map<Domain.Entities.ItemService>(request);
            return await _itemServiceRepository.UpdateItemService(itemService);
        }
    }
}
