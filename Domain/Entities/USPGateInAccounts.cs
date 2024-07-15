using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class USPGateInAccounts
    {
        public long Id { get; set; }
        public string? JobFileNo { get; set; }
        public string? ItemDesc { get; set; }
        public string? MainUnit { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? TRNo { get; set; }
        public string? RelReceiptNo { get; set; }
        public string? EIRNo { get; set; }
        public int? Qty { get; set; }

    }
}
