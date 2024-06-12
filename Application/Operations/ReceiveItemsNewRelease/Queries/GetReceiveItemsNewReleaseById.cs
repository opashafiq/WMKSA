using Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewRelease.Queries
{
    public record GetReceiveItemsNewReleaseById : IRequest<ReceiveItemsNewReleaseDto>
    {
        public int Id { get; set; }
        public GetReceiveItemsNewReleaseById(int _id)
        {
            Id = _id;
        }

    };
}
