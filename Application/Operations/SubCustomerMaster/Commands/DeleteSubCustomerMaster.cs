using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.SubCustomerMaster.Commands
{
    public class DeleteSubCustomerMaster : IRequest<Domain.Entities.SubCustomerMaster>
    {
        public int Id { get; set; }

        public DeleteSubCustomerMaster(int id)
        {
            Id = id;
        }
    }
}
