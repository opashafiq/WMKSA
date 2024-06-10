using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.UnitMaster.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.UnitMaster.QueryHandlers
{
    public class GetUnitMasterKeyValuePairHandler : IRequestHandler<GetUnitMasterKeyValuePair, ICollection<UnitMasterKeyValueDto>>
    {
        private readonly IUnitMasterRepository _unitMasterRepository;
        private readonly IMapper _mapper;
        public GetUnitMasterKeyValuePairHandler(IUnitMasterRepository unitMasterRepository, IMapper mapper)
        {
            _unitMasterRepository = unitMasterRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<UnitMasterKeyValueDto>> Handle(GetUnitMasterKeyValuePair request, CancellationToken cancellationToken)
        {
            //return await _unitMasterRepository.GetAll();
            var unitMaster = await _unitMasterRepository.GetAll();
            var unitMasterKeyValueDto = _mapper.Map<ICollection<UnitMasterKeyValueDto>>(unitMaster);
            //ICollection<UnitMasterKeyValueDto> dt = new List<UnitMasterKeyValueDto>();
            return unitMasterKeyValueDto;
        }
    }
}

