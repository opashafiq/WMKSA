using System;
using System.Collections.Generic;

namespace Application.Common.Dtos;

public partial class ReceiveItemsNewReleaseInvoiceChargeDto
{
    public long Id { get; set; }

    public long? InvoiceId { get; set; }

    public long? RecItemMasterId { get; set; }

    public long? UnitMasterId { get; set; }

    public int? ItemServiceId { get; set; }

    public decimal? BaseRate { get; set; }

    public bool? VatIncluded { get; set; }

    public decimal? VatPercentage { get; set; }

    public decimal? VatRate { get; set; }

    public decimal? Rate { get; set; }

    public int? Qty { get; set; }

    public int? TotalDays { get; set; }

    public int? FreeDays { get; set; }

    public int? ExtraDays { get; set; }

    public decimal? StorageCharge { get; set; }

    public decimal? Amount { get; set; }

    public decimal? Vatamount { get; set; }

    public decimal? NetAmount { get; set; }

    public int? IndividualUnit { get; set; }


}
