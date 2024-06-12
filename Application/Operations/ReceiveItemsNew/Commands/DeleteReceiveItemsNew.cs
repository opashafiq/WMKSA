using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNew.Commands
{
    public class DeleteReceiveItemsNew : IRequest<Domain.Entities.ReceiveItemsNew>
    {
        public int Id { get; set; }

        public DeleteReceiveItemsNew(int id)
        {
            Id = id;
        }
    }
}
