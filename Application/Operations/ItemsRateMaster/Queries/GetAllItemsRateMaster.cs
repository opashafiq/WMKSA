using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMaster.Queries
{
    public record GetAllItemsRateMaster : IRequest<ICollection<Domain.Entities.ItemsRateMaster>>
    {
        public int Id { get; set; }
        public GetAllItemsRateMaster()
        {
        }

    };
}
