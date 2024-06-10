using Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMasterDetails.Queries
{
    public record GetItemsRateMasterDetailById : IRequest<ItemsRateMasterDetailDto>
    {
        public int Id { get; set; }
        public GetItemsRateMasterDetailById(int _id)
        {
            Id = _id;
        }

    };
}
