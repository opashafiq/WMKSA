using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class SubCustomerMaster
{
    public long Id { get; set; }

    public string CustCode { get; set; } = null!;

    public string CustName { get; set; } = null!;

    public string CustAddress { get; set; } = null!;

    public string City { get; set; } = null!;

    public string CustCountry { get; set; } = null!;

    public string CustTelNo { get; set; } = null!;

    public string? CustFaxNo { get; set; }

    public string? CustEmail { get; set; }

    public string? ContactName { get; set; }

    public string? CustNameArabic { get; set; }

    public int EntryBy { get; set; }

    public DateTime EntryDate { get; set; }

    public string? CustomerType { get; set; }

    public int? CmdelFlag { get; set; }

    public string? CustAraAddr { get; set; }

    public string? ShortName { get; set; }
}
