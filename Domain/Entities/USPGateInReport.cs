using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class USPGateInReport
    {
        public string? EIRNo { get; set; }
        public string? ItemsDesc { get; set; }
        public int Qty { get; set; }
        public string? CustName { get; set; }
        public string? Condition { get; set; }
        public int EntryBy { get; set; }
        public string? DriverName { get; set; }
        public string? DriverCode { get; set; }
        public string? DrivingLiscencNo { get; set; }
        public string? MobileNo { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemDesc { get; set; }
        public string? TransName { get; set; }
        public string? ReceiveDate { get; set; }
        public string? ReceiveTime {get;set;}
    public string? Status { get; set; }
    public string? CargoType { get; set; }
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
    public string? GateClerk { get; set; }

}
}
