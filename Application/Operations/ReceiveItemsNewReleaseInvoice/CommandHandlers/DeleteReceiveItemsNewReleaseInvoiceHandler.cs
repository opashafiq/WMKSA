using Application.Abstractions;
using Application.Operations.ReceiveItemsNewReleaseInvoice.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseInvoice.CommandHandlers
{
    public class DeleteReceiveItemsNewReleaseInvoiceHandler : IRequestHandler<DeleteReceiveItemsNewReleaseInvoice, Domain.Entities.ReceiveItemsNewReleaseInvoice>
    {
        private readonly IReceiveItemsNewReleaseInvoiceRepository _receiveItemsNewReleaseInvoiceRepository;


        public DeleteReceiveItemsNewReleaseInvoiceHandler(IReceiveItemsNewReleaseInvoiceRepository receiveItemsNewReleaseInvoiceRepository)
        {
            _receiveItemsNewReleaseInvoiceRepository = receiveItemsNewReleaseInvoiceRepository;
        }

        async Task<Domain.Entities.ReceiveItemsNewReleaseInvoice> IRequestHandler<DeleteReceiveItemsNewReleaseInvoice, Domain.Entities.ReceiveItemsNewReleaseInvoice>.Handle(DeleteReceiveItemsNewReleaseInvoice request, CancellationToken cancellationToken)
        {
            return await _receiveItemsNewReleaseInvoiceRepository.DeleteReceiveItemsNewReleaseInvoice(request.Id);

        }
    }
}
