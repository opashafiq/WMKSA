using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.ReceiveItemsNewReleaseInvoiceCharge.Queries;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseInvoiceCharge.QueryHandlers
{
    public class GetReceiveItemsNewReleaseInvoiceChargeByIdHandler : IRequestHandler<GetReceiveItemsNewReleaseInvoiceChargeById, ReceiveItemsNewReleaseInvoiceChargeDto>
    {
        private readonly IReceiveItemsNewReleaseInvoiceChargeRepository _receiveItemsNewReleaseInvoiceChargeRepository;

        public GetReceiveItemsNewReleaseInvoiceChargeByIdHandler(IReceiveItemsNewReleaseInvoiceChargeRepository receiveItemsNewReleaseInvoiceChargeRepository)
        {
            _receiveItemsNewReleaseInvoiceChargeRepository = receiveItemsNewReleaseInvoiceChargeRepository;
        }

        public async Task<ReceiveItemsNewReleaseInvoiceChargeDto> Handle(GetReceiveItemsNewReleaseInvoiceChargeById request, CancellationToken cancellationToken)
        {
            var receiveItemsNewReleaseInvoiceCharge = await _receiveItemsNewReleaseInvoiceChargeRepository.GetReceiveItemsNewReleaseInvoiceChargeById(request.Id);

            ICollection<Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge> listReceiveItemsNewReleaseInvoiceCharge = new HashSet<Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge>();
            listReceiveItemsNewReleaseInvoiceCharge.Add(receiveItemsNewReleaseInvoiceCharge);

            var finalReceiveItemsNewReleaseInvoiceChargeDto =
                (from ri in listReceiveItemsNewReleaseInvoiceCharge
    
                 select new ReceiveItemsNewReleaseInvoiceChargeDto
                 {
                     Id = ri.Id,
                     InvoiceId = ri.InvoiceId,
                     RecItemMasterId = ri.RecItemMasterId,
                     UnitMasterId = ri.UnitMasterId,
                     ItemServiceId = ri.ItemServiceId,
                     BaseRate = ri.BaseRate,
                     VatIncluded = ri.VatIncluded,
                     VatPercentage = ri.VatPercentage,
                     VatRate = ri.VatRate,
                     Rate = ri.Rate,
                     Qty = ri.Qty,
                     TotalDays = ri.TotalDays,
                     FreeDays = ri.FreeDays,
                     ExtraDays = ri.ExtraDays,
                     StorageCharge = ri.StorageCharge,
                     Amount = ri.Amount,
                     Vatamount = ri.Vatamount,
                     NetAmount = ri.NetAmount,
                     IndividualUnit = ri.IndividualUnit,

                 }).ToList().FirstOrDefault();

            return finalReceiveItemsNewReleaseInvoiceChargeDto;



        }
    }
}
