using Application.Abstractions;
using Application.Operations.ReceiveItemsNewReleaseRecepit.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseRecepit.CommandHandlers
{
    public class DeleteReceiveItemsNewReleaseRecepitHandler : IRequestHandler<DeleteReceiveItemsNewReleaseRecepit, Domain.Entities.ReceiveItemsNewReleaseRecepit>
    {
        private readonly IReceiveItemsNewReleaseRecepitRepository _receiveItemsNewReleaseRecepitRepository;


        public DeleteReceiveItemsNewReleaseRecepitHandler(IReceiveItemsNewReleaseRecepitRepository receiveItemsNewReleaseRecepitRepository)
        {
            _receiveItemsNewReleaseRecepitRepository = receiveItemsNewReleaseRecepitRepository;
        }

        async Task<Domain.Entities.ReceiveItemsNewReleaseRecepit> IRequestHandler<DeleteReceiveItemsNewReleaseRecepit, Domain.Entities.ReceiveItemsNewReleaseRecepit>.Handle(DeleteReceiveItemsNewReleaseRecepit request, CancellationToken cancellationToken)
        {
            return await _receiveItemsNewReleaseRecepitRepository.DeleteReceiveItemsNewReleaseRecepit(request.Id);

        }
    }
}
