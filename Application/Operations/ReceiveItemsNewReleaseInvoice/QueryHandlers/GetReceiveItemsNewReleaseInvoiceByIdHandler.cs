using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.ReceiveItemsNewReleaseInvoice.Queries;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseInvoice.QueryHandlers
{
    public class GetReceiveItemsNewReleaseInvoiceByIdHandler : IRequestHandler<GetReceiveItemsNewReleaseInvoiceById, ReceiveItemsNewReleaseInvoiceDto>
    {
        private readonly IReceiveItemsNewReleaseInvoiceRepository _receiveItemsNewReleaseInvoiceRepository;

        public GetReceiveItemsNewReleaseInvoiceByIdHandler(IReceiveItemsNewReleaseInvoiceRepository receiveItemsNewReleaseInvoiceRepository)
        {
            _receiveItemsNewReleaseInvoiceRepository = receiveItemsNewReleaseInvoiceRepository;
        }

        public async Task<ReceiveItemsNewReleaseInvoiceDto> Handle(GetReceiveItemsNewReleaseInvoiceById request, CancellationToken cancellationToken)
        {
            var receiveItemsNewReleaseInvoice = await _receiveItemsNewReleaseInvoiceRepository.GetReceiveItemsNewReleaseInvoiceById(request.Id);

            ICollection<Domain.Entities.ReceiveItemsNewReleaseInvoice> listReceiveItemsNewReleaseInvoice = new HashSet<Domain.Entities.ReceiveItemsNewReleaseInvoice>();
            listReceiveItemsNewReleaseInvoice.Add(receiveItemsNewReleaseInvoice);

            var finalReceiveItemsNewReleaseInvoiceDto =
                (from ri in listReceiveItemsNewReleaseInvoice
    
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

                 }).ToList().FirstOrDefault();

            return finalReceiveItemsNewReleaseInvoiceDto;



        }
    }
}
