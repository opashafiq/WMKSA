using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.ReceiveItemsNew.Commands;
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
    public class GetUSPGateOutReportHandler : IRequestHandler<GetUSPGateOutReport, USPGateOutReportDto>
    {
        private readonly IReceiveItemsNewRepository _receiveItemsNewRepository;
        private readonly IRecItemMasterRepository _recItemMasterRepository;
        private readonly IUnitMasterRepository _unitMasterRepository;
        private readonly ICustomerMasterRepository _customerMasterRepository;
        private readonly ISubCustomerMasterRepository _subCustomerMasterRepository;
        private readonly IJobOrderRepository _jobOrderRepository;
        private readonly ITruckMasterRepository _truckMasterRepository;
        private readonly IDriverMasterRepository _driverMasterRepository;
        private readonly ITransporterMasterRepository _transporterMasterRepository;
        private readonly IReportRepository _reportRepository;
        public GetUSPGateOutReportHandler(
            IReceiveItemsNewRepository receiveItemsNewRepository,
            IRecItemMasterRepository recItemMasterRepository,
            IUnitMasterRepository unitMasterRepository,
            ICustomerMasterRepository customerMasterRepository,
            ISubCustomerMasterRepository subCustomerMasterRepository,
            IJobOrderRepository jobOrderRepository,
            ITruckMasterRepository truckMasterRepository,
            IDriverMasterRepository driverMasterRepository,
            ITransporterMasterRepository transporterMasterRepository,
            IReportRepository reportRepository
            )
        {
            _receiveItemsNewRepository = receiveItemsNewRepository;
            _recItemMasterRepository = recItemMasterRepository;
            _unitMasterRepository = unitMasterRepository;
            _customerMasterRepository = customerMasterRepository;
            _subCustomerMasterRepository = subCustomerMasterRepository;
            _driverMasterRepository = driverMasterRepository;
            _jobOrderRepository = jobOrderRepository;
            _transporterMasterRepository = transporterMasterRepository;
            _truckMasterRepository = truckMasterRepository;
            _reportRepository = reportRepository;
        }

        public async Task<USPGateOutReportDto> Handle(GetUSPGateOutReport request, CancellationToken cancellationToken)
        {
            var uspGateOutReport = await _reportRepository.GetUSPGateOutReport(request._receiveItemsNewReleaseId);
            ICollection<Domain.Entities.USPGateOutReport> listUSPGateOutReport = new HashSet<Domain.Entities.USPGateOutReport>();
            listUSPGateOutReport.Add(uspGateOutReport);


            var finalUSPGateInReportDto =
                    (from ri in listUSPGateOutReport

                     select new USPGateOutReportDto
                     {
                         Id = ri.Id,
                         Status = ri.Status,
                         CargoType = ri.CargoType,
                         USerName = ri.USerName,
                         EIRNo = ri.EIRNo,
                         CustName = ri.CustName,
                         SubCustName = ri.SubCustName,
                         ItemCode = ri.ItemCode,
                         ItemDesc = ri.ItemDesc,
                         Condition = ri.Condition,
                         TruckNo = ri.TruckNo,
                         DriverName = ri.DriverName,
                         DriverCode = ri.DriverCode,
                         MobileNo = ri.MobileNo,
                         TransName = ri.TransName,
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

                     }).ToList().FirstOrDefault();

            return finalUSPGateInReportDto;
        }
    }
}
