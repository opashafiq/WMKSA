using Application.Abstractions;
using Application.Operations.TransporterMaster.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.TransporterMaster.CommandHandlers
{
    public class UpdateTransporterMasterHandler : IRequestHandler<UpdateTransporterMaster, Domain.Entities.TransporterMaster>
    {
        private readonly ITransporterMasterRepository _transporterMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UpdateTransporterMasterHandler(ITransporterMasterRepository transporterMasterRepository, IMapper mapper)
        {
            _transporterMasterRepository = transporterMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.TransporterMaster> IRequestHandler<UpdateTransporterMaster, Domain.Entities.TransporterMaster>.Handle(UpdateTransporterMaster request, CancellationToken cancellationToken)
        {

            var transporterMaster = _mapper.Map<Domain.Entities.TransporterMaster>(request);
            return await _transporterMasterRepository.UpdateTransporterMaster(transporterMaster);
        }
    }
}
