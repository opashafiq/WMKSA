using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.CustomerMaster.Commands
{
    public class DeleteCustomerMaster : IRequest<Domain.Entities.CustomerMaster>
    {
        public int Id { get; set; }

        public DeleteCustomerMaster(int id)
        {
            Id = id;
        }
    }
}
