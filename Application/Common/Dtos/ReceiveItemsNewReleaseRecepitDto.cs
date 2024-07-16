using System;
using System.Collections.Generic;

namespace Application.Common.Dtos;

public partial class ReceiveItemsNewReleaseRecepitDto
{
    public long Id { get; set; }

    public long InvoiceId { get; set; }

    public int? SerialNo { get; set; }

    public string? DescGood { get; set; }

    public string? Unit { get; set; }

    public int? Qty { get; set; }

    public decimal? Rate { get; set; }

    public decimal? Amount { get; set; }

    public int? VatPercentage { get; set; }

    public decimal? VatAmount { get; set; }

    public decimal? TotalAmount { get; set; }

   
}
