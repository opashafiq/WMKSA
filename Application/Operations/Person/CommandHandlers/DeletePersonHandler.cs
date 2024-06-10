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
    public class DeletePersonHandler : IRequestHandler<DeletePerson, Domain.Entities.Person>
    {
        private readonly IPersonRepository _personRepository;


        public DeletePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }



        //async Task<Domain.Entities.Person> IRequestHandler<DeletePerson, Domain.Entities.Person>.Handle(DeletePerson request, CancellationToken cancellationToken)
        async Task<Domain.Entities.Person> IRequestHandler<DeletePerson, Domain.Entities.Person>.Handle(DeletePerson request, CancellationToken cancellationToken)
        {
            return await _personRepository.DeletePerson(request.Id);

        }
    }
}
