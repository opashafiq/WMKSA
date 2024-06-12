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
    public record GetReceiveItemsNewReleaseDetailById : IRequest<ReceiveItemsNewReleaseDetailDto>
    {
        public int Id { get; set; }
        public GetReceiveItemsNewReleaseDetailById(int _id)
        {
            Id = _id;
        }

    };
}
