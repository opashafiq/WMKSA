using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ReceiveItemsNewDto
{
    public long Id { get; set; }

    public string? Eirno { get; set; }

    public DateTime? ReceiveDate { get; set; }

    public long? RecItemMasterId { get; set; }
    public string RecItemMasterItemCode { get; set; }
    public string RecItemMasterItemDesc { get; set; }

    public string? ItemsDesc { get; set; }

    public long? UnitMasterId { get; set; }
    public string UnitMasterMainUnit { get; set; }
    public string UnitMasterUnitCode { get; set; }

    public int? Qty { get; set; }
    public int? RelasedQty { get; set; }
    public long? CustomerMasterId { get; set; }
    public string CustomerMasterCustCode { get; set; }
    public string CustomerMasterCustName { get; set; }

    public long? SubCustomerMasterId { get; set; }
    public string SubCustomerMasterCustCode { get; set; }
    public string SubCustomerMasterCustName { get; set; }

    public string? Condition { get; set; }

    public string? InvoiceNo { get; set; }

    public string? PurchaseInvoiceNo { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public string? Erpno { get; set; }

    public long? JobOrderId { get; set; }
    public string JobOrderJobFIleNo { get; set; }
    public int? JobOrderJobStatus { get; set; }


    public string? Pono { get; set; }

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

    public string? RecTime { get; set; }

    public int? EntryBy { get; set; }

    public DateTime? EntryDate { get; set; }
}
