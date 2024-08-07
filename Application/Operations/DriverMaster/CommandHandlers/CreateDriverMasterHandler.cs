﻿using Application.Abstractions;
using Application.Operations.DriverMaster.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.DriverMaster.CommandHandlers
{
    public class CreateDriverMasterHandler : IRequestHandler<CreateDriverMaster, Domain.Entities.DriverMaster>
    {
        private readonly IDriverMasterRepository _driverMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateDriverMasterHandler(IDriverMasterRepository driverMasterRepository, IMapper mapper)
        {
            _driverMasterRepository = driverMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.DriverMaster> IRequestHandler<CreateDriverMaster, Domain.Entities.DriverMaster>.Handle(CreateDriverMaster request, CancellationToken cancellationToken)
        {

            var driverMaster = _mapper.Map<Domain.Entities.DriverMaster>(request);
            if(request.ImageBase64 == null) { driverMaster.ImageBase64=null; }

            return await _driverMasterRepository.AddDriverMaster(driverMaster);
        }
    }
}
