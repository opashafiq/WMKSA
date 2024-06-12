using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class JobOrder
{
    public long Id { get; set; }

    public string? JobFileNo { get; set; }

    public DateTime? JobFileDate { get; set; }

    public long? CustomerMasterId { get; set; }

    public int? Service { get; set; }

    public string? JobStatus { get; set; }

    public string? JobRefNo { get; set; }

    public int? EntryBy { get; set; }

    public DateTime? EntryDate { get; set; }

    public virtual CustomerMaster? CustomerMaster { get; set; }

    public virtual ICollection<ReceiveItemsNewReleaseDetail> ReceiveItemsNewReleaseDetails { get; set; } = new List<ReceiveItemsNewReleaseDetail>();

    public virtual ICollection<ReceiveItemsNewRelease> ReceiveItemsNewReleases { get; set; } = new List<ReceiveItemsNewRelease>();

    public virtual ICollection<ReceiveItemsNew> ReceiveItemsNews { get; set; } = new List<ReceiveItemsNew>();
}
