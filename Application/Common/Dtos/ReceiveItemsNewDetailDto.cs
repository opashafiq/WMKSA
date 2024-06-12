using System;
using System.Collections.Generic;

namespace Application.Common.Dtos;

public partial class ReceiveItemsNewDetailDto
{
    public long Id { get; set; }

    public long? ItemsRateMasterDetailId { get; set; }
    public int ItemsRateMasterId { get; set; }

    public string ItemsRateMasterRateCode { get; set; }
    public int ItemServiceId { get; set; }
    public string ItemServiceItemsService { get; set; }
    public long RecItemMasterId { get; set; }
    public string RecItemMasterItemCode { get; set; }
    public string RecItemMasterItemDesc { get; set; }

    public long UnitMasterId { get; set; }
    public string UnitMasterMaintUnit { get; set; }
    public string UnitMasterUnitCode { get; set; }


    public int? Freedays { get; set; }

    public decimal? Charges { get; set; }

    public int? VatInc { get; set; }

    public decimal? VatP { get; set; }

    public decimal? VatAmo { get; set; }

    public decimal? Trate { get; set; }
        
}
