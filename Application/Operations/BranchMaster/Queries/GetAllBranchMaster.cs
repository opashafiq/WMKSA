using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.BranchMaster.Queries
{
    public record GetAllBranchMaster : IRequest<ICollection<Domain.Entities.BranchMaster>>
    {
        public int Id { get; set; }
        public GetAllBranchMaster()
        {
        }

    };
}
