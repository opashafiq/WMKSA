using Application.Common.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNew.Queries
{
    public record GetAllReceiveItemsNewByJobOrderId : IRequest<ICollection<ReceiveItemsNewByJobOrderIdDto>>
    {
        public long _jobOrderId { get; set; }
        public GetAllReceiveItemsNewByJobOrderId(long jobOrderId)
        {
            _jobOrderId=jobOrderId;
        }

    };
}
