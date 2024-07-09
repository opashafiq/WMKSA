using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.ReceiveItemsNewRelease.Queries;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewRelease.QueryHandlers
{
    public class GetAllReceiveItemsNewReleaseGateOutHandler : IRequestHandler<GetAllReceiveItemsNewReleaseGateOut, ICollection<ReceiveItemsNewReleaseGateOutDto>>
    {
        private readonly IReceiveItemsNewReleaseRepository _receiveItemsNewReleaseRepository;

        public GetAllReceiveItemsNewReleaseGateOutHandler(
            IReceiveItemsNewReleaseRepository receiveItemsNewReleaseRepository
            )
        {
            _receiveItemsNewReleaseRepository = receiveItemsNewReleaseRepository;
        }

        public async Task<ICollection<ReceiveItemsNewReleaseGateOutDto>> Handle(GetAllReceiveItemsNewReleaseGateOut request, CancellationToken cancellationToken)
        {
            var receiveItemsNewReleaseDto =
                (from rinr in await _receiveItemsNewReleaseRepository.GetGateOutDataAsync(
                                  request._customerId, request._subCustomerId, request._dateStart,
                                  request._dateTo, request._status, request._itemId, request._receiptNo,
                                  request._poNumber, request._truckNo, request._invoiceNo
                                  )
                 select new ReceiveItemsNewReleaseGateOutDto
                 {
                     Id = rinr.Id,
                     JobFileNo = rinr.JobFileNo,
                     CustName = rinr.CustName,
                     SubCustomerName = rinr.SubCustomerName,
                     ItemCode = rinr.ItemCode,
                     ItemDesc = rinr.ItemDesc,
                     MainUnit = rinr.MainUnit,
                     ReceiveDate = rinr.ReceiveDate,
                     ReleaseDate = rinr.ReleaseDate,
                     Days = rinr.Days,
                     Qty = rinr.Qty,
                     TRNo = rinr.TRNo,
                     RelReceiptNo = rinr.RelReceiptNo,
                     EIRNo = rinr.EIRNo,
                     CustomerMasterId = rinr.CustomerMasterId,
                     SubCustomerMasterId = rinr.SubCustomerMasterId,
                     JobOrderId = rinr.JobOrderId,
                     TruckMasterId = rinr.TruckMasterId,
                     DriverMasterId = rinr.DriverMasterId,
                     TransporterMasterId = rinr.TransporterMasterId,
                     ItemsDesc = rinr.ItemsDesc,
                     InvoiceNo = rinr.InvoiceNo,
                     PONo = rinr.PONo,
                     TruckNo = rinr.TruckNo,
                     UserName = rinr.UserName,

                 }

                 ).ToList();


            return receiveItemsNewReleaseDto;

        }
    }
}
