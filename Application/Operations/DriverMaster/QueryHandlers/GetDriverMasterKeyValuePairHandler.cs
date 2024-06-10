using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.DriverMaster.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.DriverMaster.QueryHandlers
{
    public class GetDriverMasterKeyValuePairHandler : IRequestHandler<GetDriverMasterKeyValuePair, ICollection<DriverMasterDto>>
    {
        private readonly IDriverMasterRepository _driverMasterRepository;
        private readonly IMapper _mapper;
        public GetDriverMasterKeyValuePairHandler(IDriverMasterRepository driverMasterRepository, IMapper mapper)
        {
            _driverMasterRepository = driverMasterRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<DriverMasterDto>> Handle(GetDriverMasterKeyValuePair request, CancellationToken cancellationToken)
        {
            //return await _driverMasterRepository.GetAll();
            var driverMaster = await _driverMasterRepository.GetAll();
            var driverMasterDto = _mapper.Map<ICollection<DriverMasterDto>>(driverMaster);
            //ICollection<DriverMasterDto> dt = new List<DriverMasterDto>();
            return driverMasterDto;
        }
    }
}

