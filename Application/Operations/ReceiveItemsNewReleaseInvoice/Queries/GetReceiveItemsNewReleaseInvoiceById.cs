using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dtos;

namespace Application.Operations.ReceiveItemsNewReleaseInvoice.Queries
{
    public record GetReceiveItemsNewReleaseInvoiceById : IRequest<ReceiveItemsNewReleaseInvoiceDto>
    {
        public int Id { get; set; }
        public GetReceiveItemsNewReleaseInvoiceById(int _id)
        {
            Id = _id;
        }

    };
}
