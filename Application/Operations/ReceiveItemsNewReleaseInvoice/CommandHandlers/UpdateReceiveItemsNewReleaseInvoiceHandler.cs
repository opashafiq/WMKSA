using Application.Abstractions;
using Application.Operations.ReceiveItemsNewReleaseInvoice.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseInvoice.CommandHandlers
{
    public class UpdateReceiveItemsNewReleaseInvoiceHandler : IRequestHandler<UpdateReceiveItemsNewReleaseInvoice, Domain.Entities.ReceiveItemsNewReleaseInvoice>
    {
        private readonly IReceiveItemsNewReleaseInvoiceRepository _receiveItemsNewReleaseInvoiceRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UpdateReceiveItemsNewReleaseInvoiceHandler(IReceiveItemsNewReleaseInvoiceRepository receiveItemsNewReleaseInvoiceRepository, IMapper mapper)
        {
            _receiveItemsNewReleaseInvoiceRepository = receiveItemsNewReleaseInvoiceRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.ReceiveItemsNewReleaseInvoice> IRequestHandler<UpdateReceiveItemsNewReleaseInvoice, Domain.Entities.ReceiveItemsNewReleaseInvoice>.Handle(UpdateReceiveItemsNewReleaseInvoice request, CancellationToken cancellationToken)
        {

            var receiveItemsNewReleaseInvoice = _mapper.Map<Domain.Entities.ReceiveItemsNewReleaseInvoice>(request);
            return await _receiveItemsNewReleaseInvoiceRepository.UpdateReceiveItemsNewReleaseInvoice(receiveItemsNewReleaseInvoice);
        }
    }
}
