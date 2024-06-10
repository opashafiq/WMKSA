using Application.Abstractions;
using Application.Operations.PackageMaster.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.PackageMaster.CommandHandlers
{
    public class DeletePackageMasterHandler : IRequestHandler<DeletePackageMaster, Domain.Entities.PackageMaster>
    {
        private readonly IPackageMasterRepository _packageMasterRepository;


        public DeletePackageMasterHandler(IPackageMasterRepository packageMasterRepository)
        {
            _packageMasterRepository = packageMasterRepository;
        }

        async Task<Domain.Entities.PackageMaster> IRequestHandler<DeletePackageMaster, Domain.Entities.PackageMaster>.Handle(DeletePackageMaster request, CancellationToken cancellationToken)
        {
            return await _packageMasterRepository.DeletePackageMaster(request.Id);

        }
    }
}
