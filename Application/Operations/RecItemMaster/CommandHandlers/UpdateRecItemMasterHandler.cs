using Application.Abstractions;
using Application.Operations.RecItemMaster.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.RecItemMaster.CommandHandlers
{
    public class UpdateRecItemMasterHandler : IRequestHandler<UpdateRecItemMaster, Domain.Entities.RecItemMaster>
    {
        private readonly IRecItemMasterRepository _recItemMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UpdateRecItemMasterHandler(IRecItemMasterRepository recItemMasterRepository, IMapper mapper)
        {
            _recItemMasterRepository = recItemMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.RecItemMaster> IRequestHandler<UpdateRecItemMaster, Domain.Entities.RecItemMaster>.Handle(UpdateRecItemMaster request, CancellationToken cancellationToken)
        {

            var recItemMaster = _mapper.Map<Domain.Entities.RecItemMaster>(request);
            return await _recItemMasterRepository.UpdateRecItemMaster(recItemMaster);
        }
    }
}
