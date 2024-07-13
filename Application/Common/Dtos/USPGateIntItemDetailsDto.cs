using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dtos
{
    public class USPGateIntItemDetailsDto
    {
        public long SlNo { get; set; }
        public string? JobFileNo { get; set; }
        public string? InvoiceNo { get; set; }
        public string? PONo { get; set; }
        public string? ReceiveDate { get; set; }
        public string? CustName { get; set; }
        public string? SubCustomerName { get; set; }
        public string? ItemsDesc { get; set; }
        public string? MainUnit { get; set; }
        public int Qty { get; set; }
        public string? Condition { get; set; }
        public long Id { get; set; }
        public string? EIRNo { get; set; }
        public long RecItemMasterId { get; set; }
        public long UnitMasterId { get; set; }
        public long CustomerMasterId { get; set; }
        public long SubCustomerMasterId { get; set; }
        public string? PurchaseInvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? ERPNo { get; set; }
        public long JobOrderId { get; set; }
        public int JobStatus { get; set; }
        public string? CompanyName { get; set; }
        public string? OfficeAddressLine1 { get; set; }
        public string? OfficeAddressLine2 { get; set; }
        public string? RegistrationNo { get; set; }
        public string? VATNo { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? ImageBase64 { get; set; }

    }
}
