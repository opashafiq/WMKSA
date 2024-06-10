using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.SubCustomerMaster.Queries
{
    public record GetSubCustomerMasterById : IRequest<Domain.Entities.SubCustomerMaster>
    {
        public int Id { get; set; }
        public GetSubCustomerMasterById(int _id)
        {
            Id = _id;
        }

    };
}
