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
    public record GetReceiveItemsNewById : IRequest<ReceiveItemsNewDto>
    {
        public int Id { get; set; }
        public GetReceiveItemsNewById(int _id)
        {
            Id = _id;
        }

    };
}
