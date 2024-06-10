using Application.Abstractions;
using Application.Operations.UnitMaster.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.UnitMaster.CommandHandlers
{
    public class CreateUnitMasterHandler : IRequestHandler<CreateUnitMaster, Domain.Entities.UnitMaster>
    {
        private readonly IUnitMasterRepository _unitMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateUnitMasterHandler(IUnitMasterRepository unitMasterRepository, IMapper mapper)
        {
            _unitMasterRepository = unitMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.UnitMaster> IRequestHandler<CreateUnitMaster, Domain.Entities.UnitMaster>.Handle(CreateUnitMaster request, CancellationToken cancellationToken)
        {

            var unitMaster = _mapper.Map<Domain.Entities.UnitMaster>(request);

            return await _unitMasterRepository.AddUnitMaster(unitMaster);
        }
    }
}
