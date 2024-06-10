using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.BranchMaster.Queries
{
    public record GetBranchMasterById : IRequest<Domain.Entities.BranchMaster>
    {
        public int Id { get; set; }
        public GetBranchMasterById(int _id)
        {
            Id = _id;
        }

    };
}
