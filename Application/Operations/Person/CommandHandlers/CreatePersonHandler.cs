using Application.Abstractions;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.Person.CommandHandlers
{
    public class CreatePersonHandler : IRequestHandler<CreatePerson, Domain.Entities.Person>
    {
        private readonly IPersonRepository _personRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreatePersonHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.Person> IRequestHandler<CreatePerson, Domain.Entities.Person>.Handle(CreatePerson request, CancellationToken cancellationToken)
        {
            //var person = new Domain.Entities.Person
            //{
            //    Name = request.Name,
            //    Email = request.Email
            //};

            var person = _mapper.Map<Domain.Entities.Person>(request);

            return await _personRepository.AddPerson(person);
        }
    }
}
