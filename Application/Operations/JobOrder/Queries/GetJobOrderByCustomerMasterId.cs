using Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.JobOrder.Queries
{
    public record GetJobOrderByCustomerMasterId : IRequest<ICollection<Common.Dtos.JobOrderDto>>
    {
        public long CustomerMasterId { get; set; }
        public GetJobOrderByCustomerMasterId(long _customerMasterId)
        {
            CustomerMasterId = _customerMasterId;
        }

    };
}
