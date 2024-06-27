using Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMaster.Queries
{
    public record GetItemsRateMasterById : IRequest<ItemsRateMasterDto>
    {
        public int Id { get; set; }
        public GetItemsRateMasterById(int _id)
        {
            Id = _id;
        }

    };
}
