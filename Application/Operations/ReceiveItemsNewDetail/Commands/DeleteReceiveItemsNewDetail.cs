using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewDetail.Commands
{
    public class DeleteReceiveItemsNewDetail : IRequest<Domain.Entities.ReceiveItemsNewDetail>
    {
        public int Id { get; set; }

        public DeleteReceiveItemsNewDetail(int id)
        {
            Id = id;
        }
    }
}
