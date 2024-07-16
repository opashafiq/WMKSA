using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Common.Dtos
{
    public class USPGateInChargesDto
    {
        public long ReceiveItemsNewId { get; set; }
        public long JobOrderId { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemDesc { get; set; }
        public string? ItemsService { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? Freedays { get; set; }
        public int? Qty { get; set; }
        public bool VatInc { get; set; }
        public decimal? VatP { get; set; }
        public decimal? VatAmo { get; set; }
        public decimal? TRate { get; set; }
        public int? TotDays { get; set; }
        public decimal? Charges { get; set; }
        public int? RecQty { get; set; }
        public int? Amount { get; set; }
        public int? VAT { get; set; }
        public int? TotalAmount { get; set; }
        public long? ReceiveItemsNewReleaseDetailsId { get; set; }
        public int? ItemServiceId { get; set; }

    }
}
