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
    public class CreateTruckMasterHandler : IRequestHandler<CreateTruckMaster, Domain.Entities.TruckMaster>
    {
        private readonly ITruckMasterRepository _truckMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateTruckMasterHandler(ITruckMasterRepository truckMasterRepository, IMapper mapper)
        {
            _truckMasterRepository = truckMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.TruckMaster> IRequestHandler<CreateTruckMaster, Domain.Entities.TruckMaster>.Handle(CreateTruckMaster request, CancellationToken cancellationToken)
        {

            var truckMaster = _mapper.Map<Domain.Entities.TruckMaster>(request);

            return await _truckMasterRepository.AddTruckMaster(truckMaster);
        }
    }
}
