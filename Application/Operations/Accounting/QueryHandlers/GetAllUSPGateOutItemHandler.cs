using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.ReceiveItemsNew.Queries;
using Application.Operations.Accounting.Queries;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.Accounting.QueryHandlers
{
    public class GetAllUSPGateInAccountsHandler : IRequestHandler<GetAllUSPGateInAccounts, ICollection<USPGateInAccountsDto>>
    {
      private readonly IAccountsRepository _accountsRepository;

        public GetAllUSPGateInAccountsHandler(
            IAccountsRepository accountsRepository
            )
        {
            _accountsRepository = accountsRepository;
        }

        public async Task<ICollection<USPGateInAccountsDto>> Handle(GetAllUSPGateInAccounts request, CancellationToken cancellationToken)
        {
            var uspGateInAccountsDto =
                              (from ri in await _accountsRepository.GetUSPGateInAccountsAsync(
                                  request._customerId,request._subCustomerId,request._dateStart,
                                  request._dateTo
                                  )
          
                               select new USPGateInAccountsDto
                               {
                                   Id = ri.Id,
                                   JobFileNo = ri.JobFileNo,
                                   ItemDesc = ri.ItemDesc,
                                   MainUnit = ri.MainUnit,
                                   ReceiveDate = ri.ReceiveDate,
                                   ReleaseDate = ri.ReleaseDate,
                                   TRNo = ri.TRNo,
                                   RelReceiptNo = ri.RelReceiptNo,
                                   EIRNo = ri.EIRNo,
                                   Qty = ri.Qty,

                               }).ToList();


            return uspGateInAccountsDto;
        }
    }
}
