using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.ItemService.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ServiceKey.QueryHandlers
{
    public class GetServiceKeyKeyValuePairHandler : IRequestHandler<GetItemServiceKeyValuePair, ICollection<ItemServiceKeyValueDto>>
    {
        private readonly IItemServiceRepository _serviceKeyRepository;
        private readonly IMapper _mapper;
        public GetServiceKeyKeyValuePairHandler(IItemServiceRepository serviceKeyRepository, IMapper mapper)
        {
            _serviceKeyRepository = serviceKeyRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<ItemServiceKeyValueDto>> Handle(GetItemServiceKeyValuePair request, CancellationToken cancellationToken)
        {
            //return await _serviceKeyRepository.GetAll();
            var serviceKey = await _serviceKeyRepository.GetAll();
            var serviceKeyKeyValueDto = _mapper.Map<ICollection<ItemServiceKeyValueDto>>(serviceKey);
            //ICollection<ServiceKeyKeyValueDto> dt = new List<ServiceKeyKeyValueDto>();
            return serviceKeyKeyValueDto;
        }
    }
}

