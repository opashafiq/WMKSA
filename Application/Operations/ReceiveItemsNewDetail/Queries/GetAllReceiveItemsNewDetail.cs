using Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewDetail.Queries
{
    public record GetAllReceiveItemsNewDetail : IRequest<ICollection<ReceiveItemsNewDetailDto>>
    {
        public int Id { get; set; }
        public GetAllReceiveItemsNewDetail()
        {
        }

    };
}
