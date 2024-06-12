using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ReceiveItemsNewReleaseDetailDto
{
    public long Id { get; set; }

    public long? ReceiveItemsNewReleaseId { get; set; }

    public int? Qty { get; set; }

    public long? JobOrderId { get; set; }
    public string JobOrderJobFIleNo { get; set; }
    public string JobOrderJobStatus { get; set; }

}
