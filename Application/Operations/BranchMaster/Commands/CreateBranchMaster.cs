using Lombok.NET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.BranchMaster.Commands
{
    [AllArgsConstructor]
    public partial class CreateBranchMaster : IRequest<Domain.Entities.BranchMaster>
    {
        public string BranchCode { get; set; } = null!;

        public string BranchName { get; set; } = null!;

        public string BranchTel1 { get; set; } = null!;

        public string BranchTel { get; set; } = null!;

        public string BranchAddress { get; set; } = null!;

        public string? BranchFax { get; set; }

        public string BranchIncharge { get; set; } = null!;

        public string BranchIncMobile { get; set; } = null!;

        public string BranchCity { get; set; } = null!;

        public string BranchCountry { get; set; } = null!;

        public int EntryBy { get; set; }

        public DateTime EntryDate { get; set; }

    }
}
