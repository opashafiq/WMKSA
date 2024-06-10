using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class DriverMaster
{
    public long Id { get; set; }

    public string DriverCode { get; set; } = null!;

    public string DriverName { get; set; } = null!;

    public string Company { get; set; } = null!;

    public string DrivingLiscencNo { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }

    public string IdCopy { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public string? TelNo { get; set; }

    public int EntryBy { get; set; }

    public DateTime EntryDate { get; set; }

    public string DriverNo { get; set; } = null!;

    public int TransporterMasterId { get; set; }
    public byte[]? Image { get; set; }

    public virtual ICollection<TruckMaster> TruckMasters { get; set; } = new List<TruckMaster>();

    public virtual TransporterMaster TransporterMaster { get; set; }
}
