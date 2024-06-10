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
    public class GetAllBranchMasterHandler : IRequestHandler<GetAllBranchMaster, ICollection<Domain.Entities.BranchMaster>>
    {
        private readonly IBranchMasterRepository _branchMasterRepository;

        public GetAllBranchMasterHandler(IBranchMasterRepository branchMasterRepository)
        {
            _branchMasterRepository = branchMasterRepository;
        }

        public async Task<ICollection<Domain.Entities.BranchMaster>> Handle(GetAllBranchMaster request, CancellationToken cancellationToken)
        {
            return await _branchMasterRepository.GetAll();
        }
    }
}
