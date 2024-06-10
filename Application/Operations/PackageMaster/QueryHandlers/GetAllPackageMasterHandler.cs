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
    public class GetAllPackageMasterHandler : IRequestHandler<GetAllPackageMaster, ICollection<Domain.Entities.PackageMaster>>
    {
        private readonly IPackageMasterRepository _packageMasterRepository;

        public GetAllPackageMasterHandler(IPackageMasterRepository packageMasterRepository)
        {
            _packageMasterRepository = packageMasterRepository;
        }

        public async Task<ICollection<Domain.Entities.PackageMaster>> Handle(GetAllPackageMaster request, CancellationToken cancellationToken)
        {
            return await _packageMasterRepository.GetAll();
        }
    }
}
