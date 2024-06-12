using Application.Common.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseDetail.Queries
{
    public record GetAllReceiveItemsNewReleaseDetail : IRequest<ICollection<ReceiveItemsNewReleaseDetailDto>>
    {
        public int Id { get; set; }
        public GetAllReceiveItemsNewReleaseDetail()
        {
        }

    };
}
