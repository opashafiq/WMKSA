using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dtos
{
    public class USPGateOutItemDto
    {
        public long SlNo { get; set; }
        public string JobFileNo { get; set; }
        public string PONo { get; set; }
        public string CustName { get; set; }
        public string SubCusomer { get; set; }
        public string ItemDesc { get; set; }
        public string MainUnit { get; set; }
        public string ReceiveDate { get; set; }
        public int RecQty { get; set; }
        public int ReleaseQTY { get; set; }
        public int BalQTY { get; set; }
        public int Days { get; set; }
        public string TRNo { get; set; }
        public string RelReceiptNo { get; set; }
        public string EIRNo { get; set; }
        public long CustomerMasterId { get; set; }
        public long SubCustomerMasterId { get; set; }
        public long JobOrderId { get; set; }
        public long TruckMasterId { get; set; }
        public long DriverMasterId { get; set; }
        public long TransporterMasterId { get; set; }
        public string ItemsDesc { get; set; }
        public string InvoiceNo { get; set; }
        public string TruckNo { get; set; }
        public string USerName { get; set; }
        public string ItemCode { get; set; }
        public string CompanyName { get; set; }
        public string OfficeAddressLine1 { get; set; }
        public string OfficeAddressLine2 { get; set; }
        public string RegistrationNo { get; set; }
        public string VATNo { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string ImageBase64 { get; set; }

    }
}
