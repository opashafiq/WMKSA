using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.TransporterMaster.Queries
{
    public record GetTransporterMasterById : IRequest<Domain.Entities.TransporterMaster>
    {
        public int Id { get; set; }
        public GetTransporterMasterById(int _id)
        {
            Id = _id;
        }

    };
}
