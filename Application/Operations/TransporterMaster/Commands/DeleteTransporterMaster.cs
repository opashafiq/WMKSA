using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.TransporterMaster.Commands
{
    public class DeleteTransporterMaster : IRequest<Domain.Entities.TransporterMaster>
    {
        public int Id { get; set; }

        public DeleteTransporterMaster(int id)
        {
            Id = id;
        }
    }
}
