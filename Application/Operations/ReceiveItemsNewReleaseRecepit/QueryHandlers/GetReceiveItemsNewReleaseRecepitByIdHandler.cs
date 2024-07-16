using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.ReceiveItemsNewReleaseRecepit.Queries;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseRecepit.QueryHandlers
{
    public class GetReceiveItemsNewReleaseRecepitByIdHandler : IRequestHandler<GetReceiveItemsNewReleaseRecepitById, ReceiveItemsNewReleaseRecepitDto>
    {
        private readonly IReceiveItemsNewReleaseRecepitRepository _receiveItemsNewReleaseRecepitRepository;

        public GetReceiveItemsNewReleaseRecepitByIdHandler(IReceiveItemsNewReleaseRecepitRepository receiveItemsNewReleaseRecepitRepository)
        {
            _receiveItemsNewReleaseRecepitRepository = receiveItemsNewReleaseRecepitRepository;
        }

        public async Task<ReceiveItemsNewReleaseRecepitDto> Handle(GetReceiveItemsNewReleaseRecepitById request, CancellationToken cancellationToken)
        {
            var receiveItemsNewReleaseRecepit = await _receiveItemsNewReleaseRecepitRepository.GetReceiveItemsNewReleaseRecepitById(request.Id);

            ICollection<Domain.Entities.ReceiveItemsNewReleaseRecepit> listReceiveItemsNewReleaseRecepit = new HashSet<Domain.Entities.ReceiveItemsNewReleaseRecepit>();
            listReceiveItemsNewReleaseRecepit.Add(receiveItemsNewReleaseRecepit);

            var finalReceiveItemsNewReleaseRecepitDto =
                (from ri in listReceiveItemsNewReleaseRecepit
    
                 select new ReceiveItemsNewReleaseRecepitDto
                 {
                     Id = ri.Id,
                     InvoiceId = ri.InvoiceId,
                     SerialNo = ri.SerialNo,
                     DescGood = ri.DescGood,
                     Unit = ri.Unit,
                     Qty = ri.Qty,
                     Rate = ri.Rate,
                     Amount = ri.Amount,
                     VatPercentage = ri.VatPercentage,
                     VatAmount = ri.VatAmount,
                     TotalAmount = ri.TotalAmount,

                 }).ToList().FirstOrDefault();

            return finalReceiveItemsNewReleaseRecepitDto;



        }
    }
}
