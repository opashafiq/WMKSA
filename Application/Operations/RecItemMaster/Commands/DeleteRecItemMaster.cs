using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.RecItemMaster.Commands
{
    public class DeleteRecItemMaster : IRequest<Domain.Entities.RecItemMaster>
    {
        public int Id { get; set; }

        public DeleteRecItemMaster(int id)
        {
            Id = id;
        }
    }
}
