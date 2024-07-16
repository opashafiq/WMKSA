using Lombok.NET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseRecepit.Commands
{
    [AllArgsConstructor]
    public partial class CreateReceiveItemsNewReleaseRecepit : IRequest<Domain.Entities.ReceiveItemsNewReleaseRecepit>
    {
        public long InvoiceId { get; set; }

        public int? SerialNo { get; set; }

        public string? DescGood { get; set; }

        public string? Unit { get; set; }

        public int? Qty { get; set; }

        public decimal? Rate { get; set; }

        public decimal? Amount { get; set; }

        public int? VatPercentage { get; set; }

        public decimal? VatAmount { get; set; }

        public decimal? TotalAmount { get; set; }

    }
}
