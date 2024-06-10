using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.CustomerMaster.Queries
{
    public record GetAllCustomerMaster : IRequest<ICollection<Domain.Entities.CustomerMaster>>
    {
        public int Id { get; set; }
        public GetAllCustomerMaster()
        {
        }

    };
}
