using Application.Abstractions;
using Application.Operations.ReceiveItemsNewRelease.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewRelease.CommandHandlers
{
    public class DeleteReceiveItemsNewReleaseHandler : IRequestHandler<DeleteReceiveItemsNewRelease, Domain.Entities.ReceiveItemsNewRelease>
    {
        private readonly IReceiveItemsNewReleaseRepository _receiveItemsNewReleaseRepository;


        public DeleteReceiveItemsNewReleaseHandler(IReceiveItemsNewReleaseRepository receiveItemsNewReleaseRepository)
        {
            _receiveItemsNewReleaseRepository = receiveItemsNewReleaseRepository;
        }

        async Task<Domain.Entities.ReceiveItemsNewRelease> IRequestHandler<DeleteReceiveItemsNewRelease, Domain.Entities.ReceiveItemsNewRelease>.Handle(DeleteReceiveItemsNewRelease request, CancellationToken cancellationToken)
        {
            return await _receiveItemsNewReleaseRepository.DeleteReceiveItemsNewRelease(request.Id);

        }
    }
}
