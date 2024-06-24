using Lombok.NET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.VendorMaster.Commands
{
    [AllArgsConstructor]
    public partial class CreateVendorMaster : IRequest<Domain.Entities.VendorMaster>
    {
        public string VendorCode { get; set; } = null!;

        public string VendorName { get; set; } = null!;

        public string VendorAddress { get; set; } = null!;

        public string City { get; set; } = null!;

        public string VendorCountry { get; set; } = null!;

        public string VendorTelNo { get; set; } = null!;

        public string? VendorFaxNo { get; set; }

        public string? VendorEmail { get; set; }

        public string ContactName { get; set; } = null!;

        public string? VendorNameArabic { get; set; }

        public int EntryBy { get; set; }

        public DateTime EntryDate { get; set; }

        public string BeneficiaryName { get; set; } = null!;

        public string BankName { get; set; } = null!;

        public string Iban { get; set; } = null!;

        public string Swift { get; set; } = null!;

        public string VatNo { get; set; } = null!;

        public bool DelFlag { get; set; }

        public long? VacId { get; set; }

        public string? VendAraAddr { get; set; }

    }
}
