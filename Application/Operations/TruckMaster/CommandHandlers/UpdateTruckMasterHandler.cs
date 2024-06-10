using Application.Abstractions;
using Application.Operations.TruckMaster.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.TruckMaster.CommandHandlers
{
    public class UpdateTruckMasterHandler : IRequestHandler<UpdateTruckMaster, Domain.Entities.TruckMaster>
    {
        private readonly ITruckMasterRepository _truckMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UpdateTruckMasterHandler(ITruckMasterRepository truckMasterRepository, IMapper mapper)
        {
            _truckMasterRepository = truckMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.TruckMaster> IRequestHandler<UpdateTruckMaster, Domain.Entities.TruckMaster>.Handle(UpdateTruckMaster request, CancellationToken cancellationToken)
        {

            var truckMaster = _mapper.Map<Domain.Entities.TruckMaster>(request);
            return await _truckMasterRepository.UpdateTruckMaster(truckMaster);
        }
    }
}
