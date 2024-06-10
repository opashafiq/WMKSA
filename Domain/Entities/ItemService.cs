using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ItemService
{
    public int Id { get; set; }

    public string? ItemsService { get; set; }

    public int? IndividualUnit { get; set; }

    public virtual ICollection<ItemsRateMasterDetail> ItemsRateMasterDetails { get; set; } = new List<ItemsRateMasterDetail>();
}
