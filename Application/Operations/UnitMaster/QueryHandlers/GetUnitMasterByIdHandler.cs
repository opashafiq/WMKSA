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
    public class GetUnitMasterByIdHandler : IRequestHandler<GetUnitMasterById, Domain.Entities.UnitMaster>
    {
        private readonly IUnitMasterRepository _unitMasterRepository;

        public GetUnitMasterByIdHandler(IUnitMasterRepository unitMasterRepository)
        {
            _unitMasterRepository = unitMasterRepository;
        }

        public async Task<Domain.Entities.UnitMaster> Handle(GetUnitMasterById request, CancellationToken cancellationToken)
        {
            return await _unitMasterRepository.GetUnitMasterById(request.Id);
        }
    }
}
