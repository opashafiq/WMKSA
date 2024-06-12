using Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.JobOrder.Queries
{
    public record GetJobOrderById : IRequest<Common.Dtos.JobOrderDto>
    {
        public int Id { get; set; }
        public GetJobOrderById(int _id)
        {
            Id = _id;
        }

    };
}
