using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.Person.Queries
{
    public record GetPersonById : IRequest<Domain.Entities.Person>
    {
        public int Id { get; set; }
        public GetPersonById(int _id)
        {
            Id = _id;
        }

    };
}
