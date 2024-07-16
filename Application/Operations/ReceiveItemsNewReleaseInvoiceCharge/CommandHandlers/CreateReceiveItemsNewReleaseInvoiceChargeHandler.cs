using Application.Abstractions;
using Application.Operations.ReceiveItemsNewReleaseInvoiceCharge.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseInvoiceCharge.CommandHandlers
{
    public class CreateReceiveItemsNewReleaseInvoiceChargeHandler : IRequestHandler<CreateReceiveItemsNewReleaseInvoiceCharge, Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge>
    {
        private readonly IReceiveItemsNewReleaseInvoiceChargeRepository _receiveItemsNewReleaseInvoiceChargeRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateReceiveItemsNewReleaseInvoiceChargeHandler(IReceiveItemsNewReleaseInvoiceChargeRepository receiveItemsNewReleaseInvoiceChargeRepository, IMapper mapper)
        {
            _receiveItemsNewReleaseInvoiceChargeRepository = receiveItemsNewReleaseInvoiceChargeRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge> IRequestHandler<CreateReceiveItemsNewReleaseInvoiceCharge, Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge>.Handle(CreateReceiveItemsNewReleaseInvoiceCharge request, CancellationToken cancellationToken)
        {
            var receiveItemsNewReleaseInvoiceCharge = _mapper.Map<Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge>(request);
            return await _receiveItemsNewReleaseInvoiceChargeRepository.AddReceiveItemsNewReleaseInvoiceCharge(receiveItemsNewReleaseInvoiceCharge);
        }

    }
}
