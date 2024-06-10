using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class RecItemMaster
{
    public long Id { get; set; }

    public string ItemCode { get; set; } = null!;

    public string ItemDesc { get; set; } = null!;

    public int? EntryBy { get; set; }

    public DateTime? EntryDate { get; set; }
}
