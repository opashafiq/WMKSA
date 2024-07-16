using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dtos;

namespace Application.Operations.ReceiveItemsNewReleaseRecepit.Queries
{
    public record GetAllReceiveItemsNewReleaseRecepit : IRequest<ICollection<ReceiveItemsNewReleaseRecepitDto>>
    {
        public int Id { get; set; }
        public GetAllReceiveItemsNewReleaseRecepit()
        {
        }

    };
}
