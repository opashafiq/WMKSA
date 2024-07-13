using Application.Abstractions;
using Application.Common.Dtos;
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
    public class GetUSPGateInReportHandler : IRequestHandler<GetUSPGateInReport, USPGateInReportDto>
    {
        private readonly IItemsRateMasterRepository _itemsRateMasterRepository;
        private readonly ICustomerMasterRepository _customerMasterRepository;
        private readonly IReportRepository _reportRepository;

        public GetUSPGateInReportHandler(IItemsRateMasterRepository itemsRateMasterRepository, 
            ICustomerMasterRepository customerMasterRepository,
            IReportRepository reportRepository)
        {
            _itemsRateMasterRepository = itemsRateMasterRepository;
            _customerMasterRepository = customerMasterRepository;
            _reportRepository = reportRepository;
        }

        public async Task<USPGateInReportDto> Handle(GetUSPGateInReport request, CancellationToken cancellationToken)
        {
            var uspGateInReport = await _reportRepository.GetUSPGateInReport(request._receiveItemsNewId);

            ICollection<Domain.Entities.USPGateInReport> listUSPGateInReport =
                new HashSet<Domain.Entities.USPGateInReport>();

            listUSPGateInReport.Add(uspGateInReport);
            var customerMaster = await _customerMasterRepository.GetAll();

            var finaUSPGateInReportDto =
                    (from ri in listUSPGateInReport

                     select new Common.Dtos.USPGateInReportDto
                     {
                         EIRNo = ri.EIRNo,
                         ItemsDesc = ri.ItemsDesc,
                         Qty = ri.Qty,
                         CustName = ri.CustName,
                         Condition = ri.Condition,
                         EntryBy = ri.EntryBy,
                         DriverName = ri.DriverName,
                         DriverCode = ri.DriverCode,
                         DrivingLiscencNo = ri.DrivingLiscencNo,
                         MobileNo = ri.MobileNo,
                         ItemCode = ri.ItemCode,
                         ItemDesc = ri.ItemDesc,
                         TransName = ri.TransName,
                         ReceiveDate = ri.ReceiveDate,
                         ReceiveTime = ri.ReceiveTime,
                         Status = ri.Status,
                         CargoType = ri.CargoType,
                         CompanyName = ri.CompanyName,
                         OfficeAddressLine1 = ri.OfficeAddressLine1,
                         OfficeAddressLine2 = ri.OfficeAddressLine2,
                         RegistrationNo = ri.RegistrationNo,
                         VATNo = ri.VATNo,
                         Phone = ri.Phone,
                         Fax = ri.Fax,
                         Email = ri.Email,
                         Website = ri.Website,
                         ImageBase64 = ri.filebase64 == null ? null : Convert.ToBase64String(ri.filebase64),
                         GateClerk = ri.GateClerk,


                     }).ToList().FirstOrDefault();

            return finaUSPGateInReportDto;
        }
    }
}
