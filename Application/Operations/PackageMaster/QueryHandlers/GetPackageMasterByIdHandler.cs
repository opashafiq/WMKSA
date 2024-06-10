using Application.Abstractions;
using Application.Operations.PackageMaster.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.PackageMaster.QueryHandlers
{
    public class GetPackageMasterByIdHandler : IRequestHandler<GetPackageMasterById, Domain.Entities.PackageMaster>
    {
        private readonly IPackageMasterRepository _packageMasterRepository;

        public GetPackageMasterByIdHandler(IPackageMasterRepository packageMasterRepository)
        {
            _packageMasterRepository = packageMasterRepository;
        }

        public async Task<Domain.Entities.PackageMaster> Handle(GetPackageMasterById request, CancellationToken cancellationToken)
        {
            return await _packageMasterRepository.GetPackageMasterById(request.Id);
        }
    }
}
