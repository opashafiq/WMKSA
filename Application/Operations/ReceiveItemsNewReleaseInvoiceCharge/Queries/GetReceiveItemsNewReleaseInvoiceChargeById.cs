using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dtos;

namespace Application.Operations.ReceiveItemsNewReleaseInvoiceCharge.Queries
{
    public record GetReceiveItemsNewReleaseInvoiceChargeById : IRequest<ReceiveItemsNewReleaseInvoiceChargeDto>
    {
        public int Id { get; set; }
        public GetReceiveItemsNewReleaseInvoiceChargeById(int _id)
        {
            Id = _id;
        }

    };
}
