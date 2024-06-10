using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.DriverMaster.Commands
{
    public class DeleteDriverMaster : IRequest<Domain.Entities.DriverMaster>
    {
        public int Id { get; set; }

        public DeleteDriverMaster(int id)
        {
            Id = id;
        }
    }
}
