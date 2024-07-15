using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dtos;

namespace Application.Operations.Accounting.Queries
{
    public record GetAllUSPGateInAccounts : IRequest<ICollection<USPGateInAccountsDto>>
    {
        public int? _customerId;
        public int? _subCustomerId;
        public DateTime? _dateStart;
        public DateTime? _dateTo;
        public GetAllUSPGateInAccounts(int? customerId, int? subCustomerId,
            DateTime? dateStart, DateTime? dateTo)
        {
            _customerId = customerId;
            _subCustomerId = subCustomerId;
            _dateStart = dateStart;
            _dateTo = dateTo;
        }

    };
}
