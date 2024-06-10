using Application.Abstractions;
using Application.Operations.TransporterMaster.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.TransporterMaster.QueryHandlers
{
    public class GetTransporterMasterByIdHandler : IRequestHandler<GetTransporterMasterById, Domain.Entities.TransporterMaster>
    {
        private readonly ITransporterMasterRepository _transporterMasterRepository;

        public GetTransporterMasterByIdHandler(ITransporterMasterRepository transporterMasterRepository)
        {
            _transporterMasterRepository = transporterMasterRepository;
        }

        public async Task<Domain.Entities.TransporterMaster> Handle(GetTransporterMasterById request, CancellationToken cancellationToken)
        {
            return await _transporterMasterRepository.GetTransporterMasterById(request.Id);
        }
    }
}
