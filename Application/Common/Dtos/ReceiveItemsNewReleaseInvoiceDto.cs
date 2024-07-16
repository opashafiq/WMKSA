using System;
using System.Collections.Generic;

namespace Application.Common.Dtos;

public partial class ReceiveItemsNewReleaseInvoiceDto
{
    public long Id { get; set; }

    public string? InvoiceNo { get; set; }

    public int? MonthNo { get; set; }

    public string? InvoiceMonth { get; set; }

    public int? InvoiceYear { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public DateTime? InvoiceFrom { get; set; }

    public long? CustomerMasterId { get; set; }

    public long? SubCustomerMasterId { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? Vatamount { get; set; }

    public decimal? InvoiceTotal { get; set; }

    public decimal? DiscAmount { get; set; }

    public decimal? NetAmount { get; set; }

    public string? Erpno { get; set; }

    public int? MonthId { get; set; }

    public string? InvRemarks { get; set; }

    public int? ProInvType { get; set; }

    public string? ProInvoiceNo { get; set; }

    public int? EntryBy { get; set; }

    public DateTime? EntryDate { get; set; }

    
}
