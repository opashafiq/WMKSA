using Lombok.NET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNew.Commands
{
    [AllArgsConstructor]
    public partial class UpdateReceiveItemsNew : IRequest<Domain.Entities.ReceiveItemsNew>
    {
        public long Id { get; set; }

        public string? Eirno { get; set; }

        public DateTime? ReceiveDate { get; set; }

        public long? RecItemMasterId { get; set; }

        public string? ItemsDesc { get; set; }

        public long? UnitMasterId { get; set; }

        public int? Qty { get; set; }

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
    }
}
