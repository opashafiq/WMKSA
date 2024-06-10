using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class UnitMaster
{
    public long Id { get; set; }

    public string MainUnit { get; set; } = null!;

    public string UnitInArabic { get; set; } = null!;

    public string UnitCode { get; set; } = null!;

    public int? EntryBy { get; set; }

    public DateTime? EntryDate { get; set; }
}
