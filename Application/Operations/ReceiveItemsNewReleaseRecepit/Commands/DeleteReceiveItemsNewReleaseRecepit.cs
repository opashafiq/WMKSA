using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseRecepit.Commands
{
    public class DeleteReceiveItemsNewReleaseRecepit : IRequest<Domain.Entities.ReceiveItemsNewReleaseRecepit>
    {
        public int Id { get; set; }

        public DeleteReceiveItemsNewReleaseRecepit(int id)
        {
            Id = id;
        }
    }
}
