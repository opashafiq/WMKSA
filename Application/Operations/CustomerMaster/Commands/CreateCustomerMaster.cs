using Lombok.NET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.CustomerMaster.Commands
{
    [AllArgsConstructor]
    public partial class CreateCustomerMaster : IRequest<Domain.Entities.CustomerMaster>
    {
        public string CustCode { get; set; } = null!;

        public string CustName { get; set; } = null!;

        public string CustAddress { get; set; } = null!;

        public string City { get; set; } = null!;

        public string CustCountry { get; set; } = null!;

        public string CustTelNo { get; set; } = null!;

        public string? CustFaxNo { get; set; }

        public string? CustEmail { get; set; }

        public string? ContactName { get; set; }

        public string? CustNameArabic { get; set; }

        public int EntryBy { get; set; }

        public DateTime EntryDate { get; set; }

        public string? CustomerType { get; set; }

        public int? CmDelFlag { get; set; }

        public string? CustAraAddr { get; set; }

        public string? ShortName { get; set; }

    }
}
