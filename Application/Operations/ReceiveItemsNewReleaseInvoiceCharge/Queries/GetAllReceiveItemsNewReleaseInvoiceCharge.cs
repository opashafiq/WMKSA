using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dtos;

namespace Application.Operations.ReceiveItemsNewReleaseInvoiceCharge.Queries
{
    public record GetAllReceiveItemsNewReleaseInvoiceCharge : IRequest<ICollection<ReceiveItemsNewReleaseInvoiceChargeDto>>
    {
        public int Id { get; set; }
        public GetAllReceiveItemsNewReleaseInvoiceCharge()
        {
        }

    };
}
