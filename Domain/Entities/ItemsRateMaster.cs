using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ItemsRateMaster
{
    public int Id { get; set; }

    public string RateCode { get; set; } = null!;

    public long CustomerMasterId { get; set; }

    public decimal EntryBy { get; set; }

    public DateTime EntryDate { get; set; }

    public virtual CustomerMaster CustomerMaster { get; set; } = null!;
    public virtual ICollection<ItemsRateMasterDetail> ItemsRateMasterDetails { get; set; } = new List<ItemsRateMasterDetail>();

    
}
