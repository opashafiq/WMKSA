using Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMasterDetails.Queries
{
    public record GetAllItemsRateMasterDetail : IRequest<ICollection<ItemsRateMasterDetailDto>>
    {
        public int Id { get; set; }
        public GetAllItemsRateMasterDetail()
        {
        }

    };
}
