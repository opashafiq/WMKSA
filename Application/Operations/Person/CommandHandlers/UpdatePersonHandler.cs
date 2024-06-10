using Application.Abstractions;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.Person.CommandHandlers
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePerson, Domain.Entities.Person>
    {
        private readonly IPersonRepository _personRepository;


        public UpdatePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }



        async Task<Domain.Entities.Person> IRequestHandler<UpdatePerson, Domain.Entities.Person>.Handle(UpdatePerson request, CancellationToken cancellationToken)
        {
            var person = new Domain.Entities.Person
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email
            };

            return await _personRepository.UpdatePerson(person);
        }
    }
}
