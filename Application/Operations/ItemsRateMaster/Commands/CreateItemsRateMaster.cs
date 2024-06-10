using Lombok.NET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMaster.Commands
{
    [AllArgsConstructor]
    public partial class CreateItemsRateMaster : IRequest<Domain.Entities.ItemsRateMaster>
    {
        public string RateCode { get; set; } = null!;

        public long CustomerMasterId { get; set; }

        public decimal EntryBy { get; set; }

        public DateTime EntryDate { get; set; }

    }
}
