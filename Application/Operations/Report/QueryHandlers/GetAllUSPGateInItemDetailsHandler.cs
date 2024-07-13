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
    public class GetAllUSPGateInItemDetailsHandler : IRequestHandler<GetAllUSPGateIntItemDetails, ICollection<USPGateIntItemDetailsDto>>
    {
      private readonly IReportRepository _reportRepository;

        public GetAllUSPGateInItemDetailsHandler(
            IReceiveItemsNewRepository receiveItemsNewRepository, 

            IReportRepository reportRepository
            )
        {
            _reportRepository = reportRepository;
        }

        public async Task<ICollection<USPGateIntItemDetailsDto>> Handle(GetAllUSPGateIntItemDetails request, CancellationToken cancellationToken)
        {
            var a = await _reportRepository.GetUSPGateIntItemDetailsAsync(
                                  request._customerId, request._subCustomerId, request._dateStart,
                                  request._dateTo, request._status, request._itemId, request._receiptNo,
                                  request._poNumber
                                  );
            var uspGateIntItemDetailsDto =
                              (from ri in await _reportRepository.GetUSPGateIntItemDetailsAsync(
                                  request._customerId,request._subCustomerId,request._dateStart,
                                  request._dateTo,request._status,request._itemId,request._receiptNo,
                                  request._poNumber
                                  )
          
                               select new USPGateIntItemDetailsDto
                               {
                                   SlNo = ri.SlNo,
                                   JobFileNo = ri.JobFileNo,
                                   InvoiceNo = ri.InvoiceNo,
                                   PONo = ri.PONo,
                                   ReceiveDate = ri.ReceiveDate,
                                   CustName = ri.CustName,
                                   SubCustomerName = ri.SubCustomerName,
                                   ItemsDesc = ri.ItemsDesc,
                                   MainUnit = ri.MainUnit,
                                   Qty = ri.Qty,
                                   Condition = ri.Condition,
                                   Id = ri.Id,
                                   EIRNo = ri.EIRNo,
                                   RecItemMasterId = ri.RecItemMasterId,
                                   UnitMasterId = ri.UnitMasterId,
                                   CustomerMasterId = ri.CustomerMasterId,
                                   SubCustomerMasterId = ri.SubCustomerMasterId,
                                   PurchaseInvoiceNo = ri.PurchaseInvoiceNo,
                                   InvoiceDate = ri.InvoiceDate,
                                   ERPNo = ri.ERPNo,
                                   JobOrderId = ri.JobOrderId,
                                   JobStatus = ri.JobStatus,
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


            return uspGateIntItemDetailsDto;
        }
    }
}
