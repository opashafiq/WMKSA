﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ReceiveItemsNewReleaseDetailDto
{
    public long Id { get; set; }

    public long? ReceiveItemsNewReleaseId { get; set; }

    public int? Qty { get; set; }

    public long? ReceiveItemsNewId { get; set; }
    public string? ReceiveItemsNewEIRNo { get; set; }
    

}
