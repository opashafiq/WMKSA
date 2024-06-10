using Application.Abstractions;
using Application.Operations.ItemsRateMaster.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMaster.CommandHandlers
{
    public class UpdateItemsRateMasterHandler : IRequestHandler<UpdateItemsRateMaster, Domain.Entities.ItemsRateMaster>
    {
        private readonly IItemsRateMasterRepository _itemsRateMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UpdateItemsRateMasterHandler(IItemsRateMasterRepository itemsRateMasterRepository, IMapper mapper)
        {
            _itemsRateMasterRepository = itemsRateMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.ItemsRateMaster> IRequestHandler<UpdateItemsRateMaster, Domain.Entities.ItemsRateMaster>.Handle(UpdateItemsRateMaster request, CancellationToken cancellationToken)
        {

            var itemsRateMaster = _mapper.Map<Domain.Entities.ItemsRateMaster>(request);
            return await _itemsRateMasterRepository.UpdateItemsRateMaster(itemsRateMaster);
        }
    }
}
