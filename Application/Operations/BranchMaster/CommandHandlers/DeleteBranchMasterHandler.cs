using Application.Abstractions;
using Application.Operations.BranchMaster.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.BranchMaster.CommandHandlers
{
    public class DeleteBranchMasterHandler : IRequestHandler<DeleteBranchMaster, Domain.Entities.BranchMaster>
    {
        private readonly IBranchMasterRepository _branchMasterRepository;


        public DeleteBranchMasterHandler(IBranchMasterRepository branchMasterRepository)
        {
            _branchMasterRepository = branchMasterRepository;
        }

        async Task<Domain.Entities.BranchMaster> IRequestHandler<DeleteBranchMaster, Domain.Entities.BranchMaster>.Handle(DeleteBranchMaster request, CancellationToken cancellationToken)
        {
            return await _branchMasterRepository.DeleteBranchMaster(request.Id);

        }
    }
}
