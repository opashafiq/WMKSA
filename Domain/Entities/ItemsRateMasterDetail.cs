using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ItemsRateMasterDetail
{
    public long Id { get; set; }

    public int ItemsRateMasterId { get; set; }

    public int ItemServiceId { get; set; }

    public int FreeDays { get; set; }

    public decimal Charges { get; set; }

    public int VatInc { get; set; }

    public decimal VatP { get; set; }

    public decimal VatAmo { get; set; }

    public decimal Trate { get; set; }

    public long RecItemMasterId { get; set; }

    public long UnitMasterId { get; set; }

    public virtual ItemService ItemService { get; set; } = null!;

    public virtual ItemsRateMaster ItemsRateMaster { get; set; } = null!;

    public virtual RecItemMaster RecItemMaster { get; set; } = null!;

    public virtual UnitMaster UnitMaster { get; set; } = null!;
}
