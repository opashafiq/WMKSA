using Application.Abstractions;
using Application.Operations.PackageMaster.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.PackageMaster.CommandHandlers
{
    public class UpdatePackageMasterHandler : IRequestHandler<UpdatePackageMaster, Domain.Entities.PackageMaster>
    {
        private readonly IPackageMasterRepository _packageMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UpdatePackageMasterHandler(IPackageMasterRepository packageMasterRepository, IMapper mapper)
        {
            _packageMasterRepository = packageMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.PackageMaster> IRequestHandler<UpdatePackageMaster, Domain.Entities.PackageMaster>.Handle(UpdatePackageMaster request, CancellationToken cancellationToken)
        {

            var packageMaster = _mapper.Map<Domain.Entities.PackageMaster>(request);
            return await _packageMasterRepository.UpdatePackageMaster(packageMaster);
        }
    }
}
