using Application.Abstractions;
using Application.Operations.ItemsRateMasterDetails.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMasterDetails.CommandHandlers
{
    public class UpdateItemsRateMasterDetailHandler : IRequestHandler<UpdateItemsRateMasterDetail, Domain.Entities.ItemsRateMasterDetail>
    {
        private readonly IItemsRateMasterDetailsRepository _itemsRateMasterDetailsRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UpdateItemsRateMasterDetailHandler(IItemsRateMasterDetailsRepository itemsRateMasterDetailsRepository, IMapper mapper)
        {
            _itemsRateMasterDetailsRepository = itemsRateMasterDetailsRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.ItemsRateMasterDetail> IRequestHandler<UpdateItemsRateMasterDetail, Domain.Entities.ItemsRateMasterDetail>.Handle(UpdateItemsRateMasterDetail request, CancellationToken cancellationToken)
        {

            var itemsRateMasterDetails = _mapper.Map<Domain.Entities.ItemsRateMasterDetail>(request);
            return await _itemsRateMasterDetailsRepository.UpdateItemsRateMasterDetails(itemsRateMasterDetails);
        }
    }
}
