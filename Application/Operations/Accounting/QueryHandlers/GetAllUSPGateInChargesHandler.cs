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
    public class GetAllUSPGateInChargesHandler : IRequestHandler<GetAllUSPGateInCharges, ICollection<USPGateInChargesDto>>
    {
      private readonly IAccountsRepository _accountsRepository;

        public GetAllUSPGateInChargesHandler(
            IAccountsRepository accountsRepository
            )
        {
            _accountsRepository = accountsRepository;
        }

        public async Task<ICollection<USPGateInChargesDto>> Handle(GetAllUSPGateInCharges request, CancellationToken cancellationToken)
        {
            var uspGateInChargesDto =
                              (from ri in await _accountsRepository.GetUSPGateInChargesAsync(
                                    request._receiveItemsNewIdParameter
                                  )
          
                               select new USPGateInChargesDto
                               {
                                   ReceiveItemsNewId = ri.ReceiveItemsNewId,
                                   JobOrderId = ri.JobOrderId,
                                   ItemCode = ri.ItemCode,
                                   ItemDesc = ri.ItemDesc,
                                   ItemsService = ri.ItemsService,
                                   ReceiveDate = ri.ReceiveDate,
                                   ReleaseDate = ri.ReleaseDate,
                                   Freedays = ri.Freedays,
                                   Qty = ri.Qty,
                                   VatInc = ri.VatInc,
                                   VatP = ri.VatP,
                                   VatAmo = ri.VatAmo,
                                   TRate = ri.TRate,
                                   TotDays = ri.TotDays,
                                   Charges = ri.Charges,
                                   RecQty = ri.RecQty,
                                   Amount = ri.Amount,
                                   VAT = ri.VAT,
                                   TotalAmount = ri.TotalAmount,
                                   ReceiveItemsNewReleaseDetailsId = ri.ReceiveItemsNewReleaseDetailsId,
                                   ItemServiceId = ri.ItemServiceId,


                               }).ToList();


            return uspGateInChargesDto;
        }
    }
}
