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
    public class GetAllTransporterMasterHandler : IRequestHandler<GetAllTransporterMaster, ICollection<Domain.Entities.TransporterMaster>>
    {
        private readonly ITransporterMasterRepository _transporterMasterRepository;

        public GetAllTransporterMasterHandler(ITransporterMasterRepository transporterMasterRepository)
        {
            _transporterMasterRepository = transporterMasterRepository;
        }

        public async Task<ICollection<Domain.Entities.TransporterMaster>> Handle(GetAllTransporterMaster request, CancellationToken cancellationToken)
        {
            return await _transporterMasterRepository.GetAll();
        }
    }
}
