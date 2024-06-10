using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TruckMaster
{
    public long Id { get; set; }

    public string? TruckNo { get; set; }

    public long? DriverMasterId { get; set; }

    public int? TranspoterMasterId { get; set; }

    public int EntryBy { get; set; }

    public DateTime EntryDate { get; set; }

    public virtual DriverMaster? DriverMaster { get; set; }

    public virtual TransporterMaster? TranspoterMaster { get; set; }
}
