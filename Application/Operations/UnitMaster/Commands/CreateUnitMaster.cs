using Lombok.NET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.UnitMaster.Commands
{
    [AllArgsConstructor]
    public partial class CreateUnitMaster : IRequest<Domain.Entities.UnitMaster>
    {
        public string MainUnit { get; set; } = null!;

        public string UnitInArabic { get; set; } = null!;

        public string UnitCode { get; set; } = null!;

        public int? EntryBy { get; set; }

        public DateTime? EntryDate { get; set; }

    }
}
