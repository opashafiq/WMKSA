using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.VendorMaster.Queries
{
    public record GetVendorMasterById : IRequest<Domain.Entities.VendorMaster>
    {
        public int Id { get; set; }
        public GetVendorMasterById(int _id)
        {
            Id = _id;
        }

    };
}
