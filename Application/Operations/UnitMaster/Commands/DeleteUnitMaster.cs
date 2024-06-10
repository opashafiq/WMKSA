using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.UnitMaster.Commands
{
    public class DeleteUnitMaster : IRequest<Domain.Entities.UnitMaster>
    {
        public int Id { get; set; }

        public DeleteUnitMaster(int id)
        {
            Id = id;
        }
    }
}
