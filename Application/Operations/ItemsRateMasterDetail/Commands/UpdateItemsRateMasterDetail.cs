using Lombok.NET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMasterDetails.Commands
{
    [AllArgsConstructor]
    public partial class UpdateItemsRateMasterDetail : IRequest<Domain.Entities.ItemsRateMasterDetail>
    {
        public int Id { get; set; }

        public int ItemsRateMasterId { get; set; }

        public int ItemServiceId { get; set; }

        public int FreeDays { get; set; }

        public decimal Charges { get; set; }

        public bool VatInc { get; set; }

        public decimal VatP { get; set; }

        public decimal VatAmo { get; set; }

        public decimal TRate { get; set; }

        public long RecItemMasterId { get; set; }

        public long UnitMasterId { get; set; }
    }
}
