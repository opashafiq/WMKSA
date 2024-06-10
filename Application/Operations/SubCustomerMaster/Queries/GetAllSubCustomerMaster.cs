using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.SubCustomerMaster.Queries
{
    public record GetAllSubCustomerMaster : IRequest<ICollection<Domain.Entities.SubCustomerMaster>>
    {
        public int Id { get; set; }
        public GetAllSubCustomerMaster()
        {
        }

    };
}
