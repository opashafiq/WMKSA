using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.RecItemMaster.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.RecItemMaster.QueryHandlers
{
    public class GetRecItemMasterKeyValuePairHandler : IRequestHandler<GetRecItemMasterKeyValuePair, ICollection<RecItemMasterKeyValueDto>>
    {
        private readonly IRecItemMasterRepository _recItemMasterRepository;
        private readonly IMapper _mapper;
        public GetRecItemMasterKeyValuePairHandler(IRecItemMasterRepository recItemMasterRepository, IMapper mapper)
        {
            _recItemMasterRepository = recItemMasterRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<RecItemMasterKeyValueDto>> Handle(GetRecItemMasterKeyValuePair request, CancellationToken cancellationToken)
        {
            //return await _recItemMasterRepository.GetAll();
            var recItemMaster = await _recItemMasterRepository.GetAll();
            var recItemMasterKeyValueDto = _mapper.Map<ICollection<RecItemMasterKeyValueDto>>(recItemMaster);
            //ICollection<RecItemMasterKeyValueDto> dt = new List<RecItemMasterKeyValueDto>();
            return recItemMasterKeyValueDto;
        }
    }
}

