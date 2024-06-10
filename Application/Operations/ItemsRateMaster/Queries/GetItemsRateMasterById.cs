using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMaster.Queries
{
    public record GetItemsRateMasterById : IRequest<Domain.Entities.ItemsRateMaster>
    {
        public int Id { get; set; }
        public GetItemsRateMasterById(int _id)
        {
            Id = _id;
        }

    };
}
