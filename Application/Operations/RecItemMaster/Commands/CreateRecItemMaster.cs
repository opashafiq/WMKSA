using Lombok.NET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.RecItemMaster.Commands
{
    [AllArgsConstructor]
    public partial class CreateRecItemMaster : IRequest<Domain.Entities.RecItemMaster>
    {

        public string ItemCode { get; set; } = null!;

        public string ItemDesc { get; set; } = null!;

        public int? EntryBy { get; set; }

        public DateTime? EntryDate { get; set; }

    }
}
