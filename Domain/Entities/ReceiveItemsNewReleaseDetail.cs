using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ReceiveItemsNewReleaseDetail
{
    public long Id { get; set; }

    public long? ReceiveItemsNewReleaseId { get; set; }

    public int? Qty { get; set; }

    public long? JobOrderId { get; set; }

    public virtual JobOrder? JobOrder { get; set; }

    public virtual ReceiveItemsNewRelease? ReceiveItemsNewRelease { get; set; }
}
