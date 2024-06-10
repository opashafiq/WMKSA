using Application.Abstractions;
using Application.Operations.UnitMaster.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.UnitMaster.CommandHandlers
{
    public class DeleteUnitMasterHandler : IRequestHandler<DeleteUnitMaster, Domain.Entities.UnitMaster>
    {
        private readonly IUnitMasterRepository _unitMasterRepository;


        public DeleteUnitMasterHandler(IUnitMasterRepository unitMasterRepository)
        {
            _unitMasterRepository = unitMasterRepository;
        }

        async Task<Domain.Entities.UnitMaster> IRequestHandler<DeleteUnitMaster, Domain.Entities.UnitMaster>.Handle(DeleteUnitMaster request, CancellationToken cancellationToken)
        {
            return await _unitMasterRepository.DeleteUnitMaster(request.Id);

        }
    }
}
