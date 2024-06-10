using Lombok.NET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.TransporterMaster.Commands
{
    [AllArgsConstructor]
    public partial class CreateTransporterMaster : IRequest<Domain.Entities.TransporterMaster>
    {
        public string TransCode { get; set; } = null!;

        public string TransName { get; set; } = null!;

        public string TransAddress { get; set; } = null!;

        public string City { get; set; } = null!;

        public string TransCountry { get; set; } = null!;

        public string TransTelNo { get; set; } = null!;

        public string? TransFaxNo { get; set; }

        public string TransEmail { get; set; } = null!;

        public string ContactName { get; set; } = null!;

        public string? TransNameArabic { get; set; }

        public int EntryBy { get; set; }

        public DateTime EntryDate { get; set; }

        public string? ExtNo { get; set; }

        public string? MobileNo { get; set; }

        public string? ContactName2 { get; set; }

        public string? MobileNo2 { get; set; }

    }
}
