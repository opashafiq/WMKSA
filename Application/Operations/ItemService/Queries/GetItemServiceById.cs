using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemService.Queries
{
    public record GetItemServiceById : IRequest<Domain.Entities.ItemService>
    {
        public int Id { get; set; }
        public GetItemServiceById(int _id)
        {
            Id = _id;
        }

    };
}
