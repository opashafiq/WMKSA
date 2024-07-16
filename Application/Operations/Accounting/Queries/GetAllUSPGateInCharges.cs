using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dtos;
using System.Security.Cryptography.X509Certificates;

namespace Application.Operations.Accounting.Queries
{
    public record GetAllUSPGateInCharges : IRequest<ICollection<USPGateInChargesDto>>
    {
        public string? _receiveItemsNewIdParameter;
        public GetAllUSPGateInCharges(string? receiveItemsNewIdParameter)
        {
            _receiveItemsNewIdParameter = receiveItemsNewIdParameter;
        }

    };
}
