using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.Person.Commands
{
    public class UpdatePerson : IRequest<Domain.Entities.Person>
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Email { get; set; }

        public UpdatePerson(int id, string? name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}
