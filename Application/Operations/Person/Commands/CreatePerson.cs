using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.Person.Commands
{
    public class CreatePerson : IRequest<Domain.Entities.Person>
    {
        public string? Name { get; set; }

        public string? Email { get; set; }
        public DateTime? BirthDate { get; set; }

        public CreatePerson(string? name, string email, DateTime? birthdate)
        {
            Name = name;
            Email = email;
            BirthDate = birthdate;
        }
    }
}
