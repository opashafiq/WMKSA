using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TransporterMaster
{
    public int Id { get; set; }

    public string TransCode { get; set; } = null!;

    public string TransName { get; set; } = null!;

    public string TransAddress { get; set; } = null!;

    public string City { get; set; } = null!;

    public string TransCountry { get; set; } = null!;

    public string TransTelNo { get; set; } = null!;

    public string? TransFaxNo { get; set; }

    public string TransEmail { get; set; } = null!;

    public string ContactName { get; set; } = null!;

    public string? TransNameArabic { get; set; }

    public int EntryBy { get; set; }

    public DateTime EntryDate { get; set; }

    public string? ExtNo { get; set; }

    public string? MobileNo { get; set; }

    public string? ContactName2 { get; set; }

    public string? MobileNo2 { get; set; }

    public virtual ICollection<TruckMaster> TruckMasters { get; set; } = new List<TruckMaster>();
    public virtual ICollection<DriverMaster> DriverMasters { get; set; } = new List<DriverMaster>();
}
