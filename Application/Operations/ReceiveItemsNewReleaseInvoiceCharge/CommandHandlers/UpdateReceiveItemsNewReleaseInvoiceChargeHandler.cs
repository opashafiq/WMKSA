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
    public class UpdateReceiveItemsNewReleaseInvoiceChargeHandler : IRequestHandler<UpdateReceiveItemsNewReleaseInvoiceCharge, Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge>
    {
        private readonly IReceiveItemsNewReleaseInvoiceChargeRepository _receiveItemsNewReleaseInvoiceChargeRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UpdateReceiveItemsNewReleaseInvoiceChargeHandler(IReceiveItemsNewReleaseInvoiceChargeRepository receiveItemsNewReleaseInvoiceChargeRepository, IMapper mapper)
        {
            _receiveItemsNewReleaseInvoiceChargeRepository = receiveItemsNewReleaseInvoiceChargeRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge> IRequestHandler<UpdateReceiveItemsNewReleaseInvoiceCharge, Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge>.Handle(UpdateReceiveItemsNewReleaseInvoiceCharge request, CancellationToken cancellationToken)
        {

            var receiveItemsNewReleaseInvoiceCharge = _mapper.Map<Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge>(request);
            return await _receiveItemsNewReleaseInvoiceChargeRepository.UpdateReceiveItemsNewReleaseInvoiceCharge(receiveItemsNewReleaseInvoiceCharge);
        }
    }
}
