using Lombok.NET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewRelease.Commands
{
    [AllArgsConstructor]
    public partial class CreateReceiveItemsNewRelease : IRequest<Domain.Entities.ReceiveItemsNewRelease>
    {
        public string? Eirno { get; set; }

        public long? CustomerMasterId { get; set; }

        public long? SubCustomerMasterId { get; set; }

        public long? JobOrderId { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string? Trno { get; set; }

        public string? RelReceiptNo { get; set; }

        public long? TruckMasterId { get; set; }

        public long? DriverMasterId { get; set; }

        public int? TransporterMasterId { get; set; }

        public int? EntryBy { get; set; }

        public DateTime EntryDate { get; set; }

    }
}
