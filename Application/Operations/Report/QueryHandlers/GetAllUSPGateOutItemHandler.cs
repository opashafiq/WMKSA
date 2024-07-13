using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.ReceiveItemsNew.Queries;
using Application.Operations.Report.Queries;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.Report.QueryHandlers
{
    public class GetAllUSPGateOutItemHandler : IRequestHandler<GetAllUSPGateOutItem, ICollection<USPGateOutItemDto>>
    {
      private readonly IReportRepository _reportRepository;

        public GetAllUSPGateOutItemHandler(
            IReceiveItemsNewRepository receiveItemsNewRepository, 

            IReportRepository reportRepository
            )
        {
            _reportRepository = reportRepository;
        }

        public async Task<ICollection<USPGateOutItemDto>> Handle(GetAllUSPGateOutItem request, CancellationToken cancellationToken)
        {
            var uspGateOutItemDto =
                              (from ri in await _reportRepository.GetUSPGateOutItemAsync(
                                  request._customerId,request._subCustomerId,request._dateStart,
                                  request._dateTo,request._status,request._itemId,request._receiptNo,
                                  request._poNumber,request._truckNo,request._invoiceNo
                                  )
          
                               select new USPGateOutItemDto
                               {
                                   SlNo = ri.SlNo,
                                   JobFileNo = ri.JobFileNo,
                                   PONo = ri.PONo,
                                   CustName = ri.CustName,
                                   SubCusomer = ri.SubCusomer,
                                   ItemDesc = ri.ItemDesc,
                                   MainUnit = ri.MainUnit,
                                   ReceiveDate = ri.ReceiveDate,
                                   RecQty = ri.RecQty,
                                   ReleaseQTY = ri.ReleaseQTY,
                                   BalQTY = ri.BalQTY,
                                   Days = ri.Days,
                                   TRNo = ri.TRNo,
                                   RelReceiptNo = ri.RelReceiptNo,
                                   EIRNo = ri.EIRNo,
                                   CustomerMasterId = ri.CustomerMasterId,
                                   SubCustomerMasterId = ri.SubCustomerMasterId,
                                   JobOrderId = ri.JobOrderId,
                                   TruckMasterId = ri.TruckMasterId,
                                   DriverMasterId = ri.DriverMasterId,
                                   TransporterMasterId = ri.TransporterMasterId,
                                   ItemsDesc = ri.ItemsDesc,
                                   InvoiceNo = ri.InvoiceNo,
                                   TruckNo = ri.TruckNo,
                                   USerName = ri.USerName,
                                   ItemCode = ri.ItemCode,
                                   CompanyName = ri.CompanyName,
                                   OfficeAddressLine1 = ri.OfficeAddressLine1,
                                   OfficeAddressLine2 = ri.OfficeAddressLine2,
                                   RegistrationNo = ri.RegistrationNo,
                                   VATNo = ri.VATNo,
                                   Phone = ri.Phone,
                                   Fax = ri.Fax,
                                   Email = ri.Email,
                                   Website = ri.Website,
                                   ImageBase64 = ri.filebase64 == null ? null : Convert.ToBase64String(ri.filebase64)


                               }).ToList();


            return uspGateOutItemDto;
        }
    }
}
