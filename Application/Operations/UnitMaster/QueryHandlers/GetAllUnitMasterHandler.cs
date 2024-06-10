using Application.Abstractions;
using Application.Operations.UnitMaster.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.UnitMaster.QueryHandlers
{
    public class GetAllUnitMasterHandler : IRequestHandler<GetAllUnitMaster, ICollection<Domain.Entities.UnitMaster>>
    {
        private readonly IUnitMasterRepository _unitMasterRepository;

        public GetAllUnitMasterHandler(IUnitMasterRepository unitMasterRepository)
        {
            _unitMasterRepository = unitMasterRepository;
        }

        public async Task<ICollection<Domain.Entities.UnitMaster>> Handle(GetAllUnitMaster request, CancellationToken cancellationToken)
        {
            return await _unitMasterRepository.GetAll();
        }
    }
}
