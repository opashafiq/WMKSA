using Application.Abstractions;
using Application.Operations.ReceiveItemsNew.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNew.CommandHandlers
{
    public class DeleteReceiveItemsNewHandler : IRequestHandler<DeleteReceiveItemsNew, Domain.Entities.ReceiveItemsNew>
    {
        private readonly IReceiveItemsNewRepository _receiveItemsNewRepository;


        public DeleteReceiveItemsNewHandler(IReceiveItemsNewRepository receiveItemsNewRepository)
        {
            _receiveItemsNewRepository = receiveItemsNewRepository;
        }

        async Task<Domain.Entities.ReceiveItemsNew> IRequestHandler<DeleteReceiveItemsNew, Domain.Entities.ReceiveItemsNew>.Handle(DeleteReceiveItemsNew request, CancellationToken cancellationToken)
        {
            return await _receiveItemsNewRepository.DeleteReceiveItemsNew(request.Id);

        }
    }
}
