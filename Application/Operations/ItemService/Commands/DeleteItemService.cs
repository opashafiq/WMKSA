using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemService.Commands
{
    public class DeleteItemService : IRequest<Domain.Entities.ItemService>
    {
        public int Id { get; set; }

        public DeleteItemService(int id)
        {
            Id = id;
        }
    }
}
