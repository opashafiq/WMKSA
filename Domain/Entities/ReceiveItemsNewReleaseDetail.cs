using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ReceiveItemsNewReleaseDetail
{
    public long Id { get; set; }

    public long? ReceiveItemsNewReleaseId { get; set; }

    public int? Qty { get; set; }

    public long? ReceiveItemsNewId { get; set; }

    public virtual ReceiveItemsNew? ReceiveItemsNew { get; set; }

    public virtual ReceiveItemsNewRelease? ReceiveItemsNewRelease { get; set; }
}
