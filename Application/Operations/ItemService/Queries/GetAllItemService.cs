using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemService.Queries
{
    public record GetAllItemService : IRequest<ICollection<Domain.Entities.ItemService>>
    {
        public int Id { get; set; }
        public GetAllItemService()
        {
        }

    };
}
