using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.UnitMaster.Queries
{
    public record GetAllUnitMaster : IRequest<ICollection<Domain.Entities.UnitMaster>>
    {
        public int Id { get; set; }
        public GetAllUnitMaster()
        {
        }

    };
}
