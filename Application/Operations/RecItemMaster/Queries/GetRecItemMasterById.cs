using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.RecItemMaster.Queries
{
    public record GetRecItemMasterById : IRequest<Domain.Entities.RecItemMaster>
    {
        public int Id { get; set; }
        public GetRecItemMasterById(int _id)
        {
            Id = _id;
        }

    };
}
