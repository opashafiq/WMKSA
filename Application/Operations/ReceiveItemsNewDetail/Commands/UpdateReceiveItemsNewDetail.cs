using Lombok.NET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewDetail.Commands
{
    [AllArgsConstructor]
    public partial class UpdateReceiveItemsNewDetail : IRequest<Domain.Entities.ReceiveItemsNewDetail>
    {
        public long Id { get; set; }

        public long? ItemsRateMasterDetailId { get; set; }
        public long ReceiveItemsNewId { get; set; }

        public int? Freedays { get; set; }

        public decimal? Charges { get; set; }

        public int? VatInc { get; set; }

        public decimal? VatP { get; set; }

        public decimal? VatAmo { get; set; }

        public decimal? Trate { get; set; }
    }
}
