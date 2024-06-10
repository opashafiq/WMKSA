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
    public class CreateRecItemMasterHandler : IRequestHandler<CreateRecItemMaster, Domain.Entities.RecItemMaster>
    {
        private readonly IRecItemMasterRepository _recItemMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateRecItemMasterHandler(IRecItemMasterRepository recItemMasterRepository, IMapper mapper)
        {
            _recItemMasterRepository = recItemMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.RecItemMaster> IRequestHandler<CreateRecItemMaster, Domain.Entities.RecItemMaster>.Handle(CreateRecItemMaster request, CancellationToken cancellationToken)
        {

            var recItemMaster = _mapper.Map<Domain.Entities.RecItemMaster>(request);

            return await _recItemMasterRepository.AddRecItemMaster(recItemMaster);
        }
    }
}
