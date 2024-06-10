using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.TruckMaster.Commands
{
    public class DeleteTruckMaster : IRequest<Domain.Entities.TruckMaster>
    {
        public int Id { get; set; }

        public DeleteTruckMaster(int id)
        {
            Id = id;
        }
    }
}
