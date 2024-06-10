using Lombok.NET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.PackageMaster.Commands
{
    [AllArgsConstructor]
    public partial class CreatePackageMaster : IRequest<Domain.Entities.PackageMaster>
    {
        public string PackageCode { get; set; } = null!;

        public string PackageName { get; set; } = null!;

        public string PackageNameAra { get; set; } = null!;

        public long EntryBy { get; set; }

        public DateTime EntryDate { get; set; }

    }
}
