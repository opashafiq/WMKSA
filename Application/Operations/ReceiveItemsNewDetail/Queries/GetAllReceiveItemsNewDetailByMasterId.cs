using Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewDetail.Queries
{
    public record GetAllReceiveItemsNewDetailByMasterId : IRequest<ICollection<ReceiveItemsNewDetailDto>>
    {
        public long ReceiveItemsNewId { get; set; }
        public GetAllReceiveItemsNewDetailByMasterId(long receiveItemsNewId)
        {
            ReceiveItemsNewId = receiveItemsNewId;
        }

    };
}
