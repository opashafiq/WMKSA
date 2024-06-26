﻿using Application.Abstractions;
using Application.Operations.CustomerMaster.Commands;
using Application.Operations.Person.Commands;
using Application.Operations.SubCustomerMaster.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.SubCustomerMaster.CommandHandlers
{
    public class UpdateSubCustomerMasterHandler : IRequestHandler<UpdateSubCustomerMaster, Domain.Entities.SubCustomerMaster>
    {
        private readonly ISubCustomerMasterRepository _subCustomerMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UpdateSubCustomerMasterHandler(ISubCustomerMasterRepository subCustomerMasterRepository, IMapper mapper)
        {
            _subCustomerMasterRepository = subCustomerMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.SubCustomerMaster> IRequestHandler<UpdateSubCustomerMaster, Domain.Entities.SubCustomerMaster>.Handle(UpdateSubCustomerMaster request, CancellationToken cancellationToken)
        {

            var subCustomerMaster = _mapper.Map<Domain.Entities.SubCustomerMaster>(request);
            return await _subCustomerMasterRepository.UpdateSubCustomerMaster(subCustomerMaster);
        }
    }
}
