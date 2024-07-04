using Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMasterDetails.Queries
{
    public record GetAllItemsRateMasterDetailByMasterId : IRequest<ICollection<ItemsRateMasterDetailDto>>
    {
        public int Id { get; set; }
        public long _MasterId { get; set; }
        public GetAllItemsRateMasterDetailByMasterId(long MasterId)
        {
            _MasterId = MasterId;
        }

    };
}
