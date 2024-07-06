using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ReceiveItemsNewDetail
{
    public long Id { get; set; }

    public long? ItemsRateMasterDetailId { get; set; }
    public long ReceiveItemsNewId { get; set; }

    public int? Freedays { get; set; }

    public decimal? Charges { get; set; }

    public int? VatInc { get; set; }

    public decimal? VatP { get; set; }

    public decimal? VatAmo { get; set; }

    public decimal? Trate { get; set; }

    public virtual ItemsRateMasterDetail? ItemsRateMasterDetail { get; set; }
    public virtual ReceiveItemsNew? ReceiveItemsNew { get; set; }
}
