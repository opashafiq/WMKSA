using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ReceiveItemsNewReleaseGateOut
{
    public long Id { get; set; }

    public string JobFileNo { get; set; }
    public string CustName { get; set; }
    public string SubCustomerName { get; set; }
    public string ItemCode { get; set; }
    public string ItemDesc { get; set; }
    public string MainUnit { get; set; }
    public DateTime? ReceiveDate { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public int Days { get; set; }
    public int Qty { get; set; }
    public string TRNo{ get; set; }
    public string RelReceiptNo { get; set; }
    public string? EIRNo { get; set; }

    public long? CustomerMasterId { get; set; }

    public long? SubCustomerMasterId { get; set; }

    public long? JobOrderId { get; set; }

    public long? TruckMasterId { get; set; }

    public long? DriverMasterId { get; set; }

    public int? TransporterMasterId { get; set; }
    public string ItemsDesc { get; set; }
    public string InvoiceNo{ get; set; }
    public string PONo { get; set; }
    public string TruckNo { get; set; }
    public string UserName { get; set; }
    
}
