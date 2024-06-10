using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.UnitMaster.Queries
{
    public record GetUnitMasterById : IRequest<Domain.Entities.UnitMaster>
    {
        public int Id { get; set; }
        public GetUnitMasterById(int _id)
        {
            Id = _id;
        }

    };
}
