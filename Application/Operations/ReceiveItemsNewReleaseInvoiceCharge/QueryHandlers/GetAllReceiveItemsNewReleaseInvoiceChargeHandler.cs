using Application.Abstractions;
using Application.Operations.ReceiveItemsNewReleaseInvoiceCharge.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dtos;

namespace Application.Operations.ReceiveItemsNewReleaseInvoiceCharge.QueryHandlers
{
    public class GetAllReceiveItemsNewReleaseInvoiceChargeHandler : IRequestHandler<GetAllReceiveItemsNewReleaseInvoiceCharge, ICollection<ReceiveItemsNewReleaseInvoiceChargeDto>>
    {
        private readonly IReceiveItemsNewReleaseInvoiceChargeRepository _receiveItemsNewReleaseInvoiceChargeRepository;

        public GetAllReceiveItemsNewReleaseInvoiceChargeHandler(IReceiveItemsNewReleaseInvoiceChargeRepository receiveItemsNewReleaseInvoiceChargeRepository)
        {
            _receiveItemsNewReleaseInvoiceChargeRepository = receiveItemsNewReleaseInvoiceChargeRepository;
        }

        public async Task<ICollection<ReceiveItemsNewReleaseInvoiceChargeDto>> Handle(GetAllReceiveItemsNewReleaseInvoiceCharge request, CancellationToken cancellationToken)
        {
            var receiveItemsNewReleaseInvoiceChargeDto =
                  (from ri in await _receiveItemsNewReleaseInvoiceChargeRepository.GetAll()

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
                   }).ToList<ReceiveItemsNewReleaseInvoiceChargeDto>();

            return receiveItemsNewReleaseInvoiceChargeDto;
        }
    }
}
