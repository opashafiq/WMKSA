using System;
using System.Collections.Generic;

namespace Application.Common.Dtos;

public partial class ReceiveItemsNewReleaseDto
{
    public long Id { get; set; }

    public string? Eirno { get; set; }

    public long? CustomerMasterId { get; set; }
    public string CustomerMasterCustCode { get; set; }
    public string CustomerMasterCustName { get; set; }

    public long? SubCustomerMasterId { get; set; }
    public string SubCustomerMasterCustCode { get; set; }
    public string SubCustomerMasterCustName { get; set; }

    public long? JobOrderId { get; set; }
    public string JobOrderJobFIleNo { get; set; }
    public string JobOrderJobStatus { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public string? Trno { get; set; }

    public string? RelReceiptNo { get; set; }

    public long? TruckMasterId { get; set; }
    public string TruckMasterTruckNo { get; set; }

    public long? DriverMasterId { get; set; }
    public string DriverMasterDriverCode { get; set; }
    public string DriverMasterDriverName { get; set; }
    public string DriverMasterCompany { get; set; }
    public string DriverMasterDrivingLiscencNo { get; set; }
    public string DriverMasterIDCopy { get; set; }
    public string DriverMasterMobileNo { get; set; }
    public int? TransporterMasterId { get; set; }
    public string TransporterMasterTransCode { get; set; }
    public string TransporterMasterTransName { get; set; }
    public int? EntryBy { get; set; }

    public DateTime EntryDate { get; set; }

}
