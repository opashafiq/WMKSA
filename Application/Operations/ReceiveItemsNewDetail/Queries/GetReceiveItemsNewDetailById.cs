using Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewDetail.Queries
{
    public record GetReceiveItemsNewDetailById : IRequest<ReceiveItemsNewDetailDto>
    {
        public int Id { get; set; }
        public GetReceiveItemsNewDetailById(int _id)
        {
            Id = _id;
        }

    };
}
