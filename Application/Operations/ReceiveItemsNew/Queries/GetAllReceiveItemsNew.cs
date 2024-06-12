using Application.Common.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNew.Queries
{
    public record GetAllReceiveItemsNew : IRequest<ICollection<ReceiveItemsNewDto>>
    {
        public int Id { get; set; }
        public GetAllReceiveItemsNew()
        {
        }

    };
}
