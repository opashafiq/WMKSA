using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewRelease.Commands
{
    public class DeleteReceiveItemsNewRelease : IRequest<Domain.Entities.ReceiveItemsNewRelease>
    {
        public int Id { get; set; }

        public DeleteReceiveItemsNewRelease(int id)
        {
            Id = id;
        }
    }
}
