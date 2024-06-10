using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.ItemsRateMaster.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMaster.QueryHandlers
{
    public class GetItemsRateMasterKeyValuePairHandler : IRequestHandler<GetItemsRateMasterKeyValuePair, ICollection<ItemsRateMasterKeyValueDto>>
    {
        private readonly IItemsRateMasterRepository _itemsRateMasterRepository;
        private readonly IMapper _mapper;
        public GetItemsRateMasterKeyValuePairHandler(IItemsRateMasterRepository itemsRateMasterRepository, IMapper mapper)
        {
            _itemsRateMasterRepository = itemsRateMasterRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<ItemsRateMasterKeyValueDto>> Handle(GetItemsRateMasterKeyValuePair request, CancellationToken cancellationToken)
        {
            var itemsRateMaster = await _itemsRateMasterRepository.GetAll();
            var itemsRateMasterKeyValueDto = _mapper.Map<ICollection<ItemsRateMasterKeyValueDto>>(itemsRateMaster);
            return itemsRateMasterKeyValueDto;
        }
    }
}

