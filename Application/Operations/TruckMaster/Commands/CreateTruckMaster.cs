using Lombok.NET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.TruckMaster.Commands
{
    [AllArgsConstructor]
    public partial class CreateTruckMaster : IRequest<Domain.Entities.TruckMaster>
    {
        public string? TruckNo { get; set; }

        public long? DriverMasterId { get; set; }

        public int? TranspoterMasterId { get; set; }

        public int EntryBy { get; set; }

        public DateTime EntryDate { get; set; }



    }
}
