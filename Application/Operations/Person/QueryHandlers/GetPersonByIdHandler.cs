using Application.Abstractions;
using Application.Operations.Person.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.Person.QueryHandlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonById, Domain.Entities.Person>
    {
        private readonly IPersonRepository _personRepository;

        public GetPersonByIdHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Domain.Entities.Person> Handle(GetPersonById request, CancellationToken cancellationToken)
        {
            return await _personRepository.GetPersonById(request.Id);
        }
    }
}
