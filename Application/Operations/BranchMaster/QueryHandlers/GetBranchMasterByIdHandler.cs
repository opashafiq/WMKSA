using Application.Abstractions;
using Application.Operations.BranchMaster.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.BranchMaster.QueryHandlers
{
    public class GetBranchMasterByIdHandler : IRequestHandler<GetBranchMasterById, Domain.Entities.BranchMaster>
    {
        private readonly IBranchMasterRepository _branchMasterRepository;

        public GetBranchMasterByIdHandler(IBranchMasterRepository branchMasterRepository)
        {
            _branchMasterRepository = branchMasterRepository;
        }

        public async Task<Domain.Entities.BranchMaster> Handle(GetBranchMasterById request, CancellationToken cancellationToken)
        {
            return await _branchMasterRepository.GetBranchMasterById(request.Id);
        }
    }
}
