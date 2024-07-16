using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dtos;

namespace Application.Operations.ReceiveItemsNewReleaseRecepit.Queries
{
    public record GetReceiveItemsNewReleaseRecepitById : IRequest<ReceiveItemsNewReleaseRecepitDto>
    {
        public int Id { get; set; }
        public GetReceiveItemsNewReleaseRecepitById(int _id)
        {
            Id = _id;
        }

    };
}
