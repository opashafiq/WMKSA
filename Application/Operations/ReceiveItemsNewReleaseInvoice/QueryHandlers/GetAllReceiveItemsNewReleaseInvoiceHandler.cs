using Application.Abstractions;
using Application.Operations.ReceiveItemsNewReleaseInvoice.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dtos;

namespace Application.Operations.ReceiveItemsNewReleaseInvoice.QueryHandlers
{
    public class GetAllReceiveItemsNewReleaseInvoiceHandler : IRequestHandler<GetAllReceiveItemsNewReleaseInvoice, ICollection<ReceiveItemsNewReleaseInvoiceDto>>
    {
        private readonly IReceiveItemsNewReleaseInvoiceRepository _receiveItemsNewReleaseInvoiceRepository;

        public GetAllReceiveItemsNewReleaseInvoiceHandler(IReceiveItemsNewReleaseInvoiceRepository receiveItemsNewReleaseInvoiceRepository)
        {
            _receiveItemsNewReleaseInvoiceRepository = receiveItemsNewReleaseInvoiceRepository;
        }

        public async Task<ICollection<ReceiveItemsNewReleaseInvoiceDto>> Handle(GetAllReceiveItemsNewReleaseInvoice request, CancellationToken cancellationToken)
        {
            var receiveItemsNewReleaseInvoiceDto =
                  (from ri in await _receiveItemsNewReleaseInvoiceRepository.GetAll()

                   select new ReceiveItemsNewReleaseInvoiceDto
                   {
                       Id = ri.Id,
                       InvoiceNo = ri.InvoiceNo,
                       MonthNo = ri.MonthNo,
                       InvoiceMonth = ri.InvoiceMonth,
                       InvoiceYear = ri.InvoiceYear,
                       InvoiceDate = ri.InvoiceDate,
                       InvoiceFrom = ri.InvoiceFrom,
                       CustomerMasterId = ri.CustomerMasterId,
                       SubCustomerMasterId = ri.SubCustomerMasterId,
                       TotalAmount = ri.TotalAmount,
                       Vatamount = ri.Vatamount,
                       InvoiceTotal = ri.InvoiceTotal,
                       DiscAmount = ri.DiscAmount,
                       NetAmount = ri.NetAmount,
                       Erpno = ri.Erpno,
                       MonthId = ri.MonthId,
                       InvRemarks = ri.InvRemarks,
                       ProInvType = ri.ProInvType,
                       ProInvoiceNo = ri.ProInvoiceNo,
                       EntryBy = ri.EntryBy,
                       EntryDate = ri.EntryDate,
                   }).ToList<ReceiveItemsNewReleaseInvoiceDto>();

            return receiveItemsNewReleaseInvoiceDto;
        }
    }
}
