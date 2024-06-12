using Lombok.NET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.JobOrder.Commands
{
    [AllArgsConstructor]
    public partial class CreateJobOrder : IRequest<Domain.Entities.JobOrder>
    {
        public string? JobFileNo { get; set; }

        public DateTime? JobFileDate { get; set; }

        public long? CustomerMasterId { get; set; }

        public int? Service { get; set; }

        public string? JobStatus { get; set; }

        public string? JobRefNo { get; set; }

        public int? EntryBy { get; set; }

        public DateTime? EntryDate { get; set; }

    }
}
