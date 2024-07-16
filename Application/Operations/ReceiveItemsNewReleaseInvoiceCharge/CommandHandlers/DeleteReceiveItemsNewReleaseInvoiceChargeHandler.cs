using Application.Abstractions;
using Application.Operations.ReceiveItemsNewReleaseInvoiceCharge.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseInvoiceCharge.CommandHandlers
{
    public class DeleteReceiveItemsNewReleaseInvoiceChargeHandler : IRequestHandler<DeleteReceiveItemsNewReleaseInvoiceCharge, Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge>
    {
        private readonly IReceiveItemsNewReleaseInvoiceChargeRepository _receiveItemsNewReleaseInvoiceChargeRepository;


        public DeleteReceiveItemsNewReleaseInvoiceChargeHandler(IReceiveItemsNewReleaseInvoiceChargeRepository receiveItemsNewReleaseInvoiceChargeRepository)
        {
            _receiveItemsNewReleaseInvoiceChargeRepository = receiveItemsNewReleaseInvoiceChargeRepository;
        }

        async Task<Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge> IRequestHandler<DeleteReceiveItemsNewReleaseInvoiceCharge, Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge>.Handle(DeleteReceiveItemsNewReleaseInvoiceCharge request, CancellationToken cancellationToken)
        {
            return await _receiveItemsNewReleaseInvoiceChargeRepository.DeleteReceiveItemsNewReleaseInvoiceCharge(request.Id);

        }
    }
}
