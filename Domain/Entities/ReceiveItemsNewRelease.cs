using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ReceiveItemsNewRelease
{
    public long Id { get; set; }

    public string? Eirno { get; set; }

    public long? CustomerMasterId { get; set; }

    public long? SubCustomerMasterId { get; set; }

    public long? JobOrderId { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public string? Trno { get; set; }

    public string? RelReceiptNo { get; set; }

    public long? TruckMasterId { get; set; }

    public long? DriverMasterId { get; set; }

    public int? TransporterMasterId { get; set; }

    public int? EntryBy { get; set; }

    public DateTime EntryDate { get; set; }

    public virtual CustomerMaster? CustomerMaster { get; set; }

    public virtual JobOrder? JobOrder { get; set; }

    public virtual ICollection<ReceiveItemsNewReleaseDetail> ReceiveItemsNewReleaseDetails { get; set; } = new List<ReceiveItemsNewReleaseDetail>();

    public virtual SubCustomerMaster? SubCustomerMaster { get; set; }

    public virtual TransporterMaster? TransporterMaster { get; set; }

    public virtual DriverMaster? DriverMaster { get; set; }

    public virtual TruckMaster? TruckMaster { get; set; }
}
