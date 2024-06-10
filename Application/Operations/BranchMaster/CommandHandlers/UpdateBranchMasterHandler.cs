using Application.Abstractions;
using Application.Operations.BranchMaster.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.BranchMaster.CommandHandlers
{
    public class UpdateBranchMasterHandler : IRequestHandler<UpdateBranchMaster, Domain.Entities.BranchMaster>
    {
        private readonly IBranchMasterRepository _branchMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UpdateBranchMasterHandler(IBranchMasterRepository branchMasterRepository, IMapper mapper)
        {
            _branchMasterRepository = branchMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.BranchMaster> IRequestHandler<UpdateBranchMaster, Domain.Entities.BranchMaster>.Handle(UpdateBranchMaster request, CancellationToken cancellationToken)
        {

            var branchMaster = _mapper.Map<Domain.Entities.BranchMaster>(request);
            return await _branchMasterRepository.UpdateBranchMaster(branchMaster);
        }
    }
}
