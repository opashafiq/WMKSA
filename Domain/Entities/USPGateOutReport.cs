using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class USPGateOutReport
{
    public long Id { get; set; }
    public string? Status { get; set; }
    public string? CargoType { get; set; }
    public string? USerName { get; set; }
    public string? EIRNo { get; set; }
    public string? CustName { get; set; }
    public string? SubCustName { get; set; }
    public string? ItemCode { get; set; }
    public string? ItemDesc { get; set; }
    public string? Condition { get; set; }
    public string? TruckNo { get; set; }
    public string? DriverName { get; set; }
    public string? DriverCode { get; set; }
    public string? MobileNo { get; set; }
    public string? TransName { get; set; }
    public string? CompanyName { get; set; }
    public string? OfficeAddressLine1 { get; set; }
    public string? OfficeAddressLine2 { get; set; }
    public string? RegistrationNo { get; set; }
    public string? VATNo { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public byte[]? filebase64 { get; set; }

}