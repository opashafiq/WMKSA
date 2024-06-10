using Application.Abstractions;
using Application.Operations.TransporterMaster.Commands;
using MediatR;

namespace Application.Operations.TransporterMaster.CommandHandlers
{
    public class DeleteTransporterMasterHandler : IRequestHandler<DeleteTransporterMaster, Domain.Entities.TransporterMaster>
    {
        private readonly ITransporterMasterRepository _transporterMasterRepository;


        public DeleteTransporterMasterHandler(ITransporterMasterRepository transporterMasterRepository)
        {
            _transporterMasterRepository = transporterMasterRepository;
        }

        async Task<Domain.Entities.TransporterMaster> IRequestHandler<DeleteTransporterMaster, Domain.Entities.TransporterMaster>.Handle(DeleteTransporterMaster request, CancellationToken cancellationToken)
        {
            return await _transporterMasterRepository.DeleteTransporterMaster(request.Id);

        }
    }
}
