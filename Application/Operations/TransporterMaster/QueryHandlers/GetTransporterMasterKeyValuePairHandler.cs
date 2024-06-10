using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.TransporterMaster.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.TransporterMaster.QueryHandlers
{
    public class GetTransporterMasterKeyValuePairHandler : IRequestHandler<GetTransporterMasterKeyValuePair, ICollection<TransporterMasterKeyValueDto>>
    {
        private readonly ITransporterMasterRepository _transporterMasterRepository;
        private readonly IMapper _mapper;
        public GetTransporterMasterKeyValuePairHandler(ITransporterMasterRepository transporterMasterRepository, IMapper mapper)
        {
            _transporterMasterRepository = transporterMasterRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<TransporterMasterKeyValueDto>> Handle(GetTransporterMasterKeyValuePair request, CancellationToken cancellationToken)
        {
            //return await _transporterMasterRepository.GetAll();
            var transporterMaster = await _transporterMasterRepository.GetAll();
            var transporterMasterKeyValueDto = _mapper.Map<ICollection<TransporterMasterKeyValueDto>>(transporterMaster);
            //ICollection<TransporterMasterKeyValueDto> dt = new List<TransporterMasterKeyValueDto>();
            return transporterMasterKeyValueDto;
        }
    }
}

