using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMaster.Commands
{
    public class DeleteItemsRateMaster : IRequest<Domain.Entities.ItemsRateMaster>
    {
        public int Id { get; set; }

        public DeleteItemsRateMaster(int id)
        {
            Id = id;
        }
    }
}
