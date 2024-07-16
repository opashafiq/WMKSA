using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseInvoiceCharge.Commands
{
    public class DeleteReceiveItemsNewReleaseInvoiceCharge : IRequest<Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge>
    {
        public int Id { get; set; }

        public DeleteReceiveItemsNewReleaseInvoiceCharge(int id)
        {
            Id = id;
        }
    }
}
