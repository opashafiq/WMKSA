using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseDetail.Commands
{
    public class DeleteReceiveItemsNewReleaseDetail : IRequest<Domain.Entities.ReceiveItemsNewReleaseDetail>
    {
        public int Id { get; set; }

        public DeleteReceiveItemsNewReleaseDetail(int id)
        {
            Id = id;
        }
    }
}
