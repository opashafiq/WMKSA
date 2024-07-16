using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseInvoice.Commands
{
    public class DeleteReceiveItemsNewReleaseInvoice : IRequest<Domain.Entities.ReceiveItemsNewReleaseInvoice>
    {
        public int Id { get; set; }

        public DeleteReceiveItemsNewReleaseInvoice(int id)
        {
            Id = id;
        }
    }
}
