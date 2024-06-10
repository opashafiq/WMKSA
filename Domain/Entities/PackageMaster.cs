using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class PackageMaster
{
    public long Id { get; set; }

    public string PackageCode { get; set; } = null!;

    public string PackageName { get; set; } = null!;

    public string PackageNameAra { get; set; } = null!;

    public long EntryBy { get; set; }

    public DateTime EntryDate { get; set; }
}
