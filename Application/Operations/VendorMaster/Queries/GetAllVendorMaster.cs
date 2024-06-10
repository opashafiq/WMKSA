using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.VendorMaster.Queries
{
    public record GetAllVendorMaster : IRequest<ICollection<Domain.Entities.VendorMaster>>
    {
        public int Id { get; set; }
        public GetAllVendorMaster()
        {
        }

    };
}
