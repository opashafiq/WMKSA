using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.VendorMaster.Commands
{
    public class DeleteVendorMaster : IRequest<Domain.Entities.VendorMaster>
    {
        public int Id { get; set; }

        public DeleteVendorMaster(int id)
        {
            Id = id;
        }
    }
}
