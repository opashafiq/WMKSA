using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.JobOrder.Commands
{
    public class DeleteJobOrder : IRequest<Domain.Entities.JobOrder>
    {
        public int Id { get; set; }

        public DeleteJobOrder(int id)
        {
            Id = id;
        }
    }
}
