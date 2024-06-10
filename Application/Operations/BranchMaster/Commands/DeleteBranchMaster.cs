using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.BranchMaster.Commands
{
    public class DeleteBranchMaster : IRequest<Domain.Entities.BranchMaster>
    {
        public int Id { get; set; }

        public DeleteBranchMaster(int id)
        {
            Id = id;
        }
    }
}
