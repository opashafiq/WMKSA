using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class ReceiveItemsNew
    {
        public long Id { get; set; }

        public string? Eirno { get; set; }

        public DateTime? ReceiveDate { get; set; }

        public long? RecItemMasterId { get; set; }

        public string? ItemsDesc { get; set; }

        public long? UnitMasterId { get; set; }

        public int? Qty { get; set; }
        public int? RelasedQty { get; set; }

        public long? CustomerMasterId { get; set; }

        public long? SubCustomerMasterId { get; set; }

        public string? Condition { get; set; }

        public string? InvoiceNo { get; set; }

        public string? PurchaseInvoiceNo { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public string? Erpno { get; set; }

        public long? JobOrderId { get; set; }

        public string? Pono { get; set; }

        public long? TruckMasterId { get; set; }

        public long? DriverMasterId { get; set; }

        public int? TransporterMasterId { get; set; }

        public string? RecTime { get; set; }

        public int? EntryBy { get; set; }

        public DateTime? EntryDate { get; set; }

        public virtual CustomerMaster? CustomerMaster { get; set; }

        public virtual DriverMaster? DriverMaster { get; set; }

        public virtual JobOrder? JobOrder { get; set; }

        public virtual RecItemMaster? RecItemMaster { get; set; }

        public virtual SubCustomerMaster? SubCustomerMaster { get; set; }

        public virtual TransporterMaster? TransporterMaster { get; set; }

        public virtual TruckMaster? TruckMaster { get; set; }

        public virtual UnitMaster? UnitMaster { get; set; }
    }
}
