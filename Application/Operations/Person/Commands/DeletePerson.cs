using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.Person.Commands
{
    public class DeletePerson : IRequest<Domain.Entities.Person>
    {
        public int Id { get; set; }

        public DeletePerson(int id)
        {
            Id = id;
        }
    }
}
