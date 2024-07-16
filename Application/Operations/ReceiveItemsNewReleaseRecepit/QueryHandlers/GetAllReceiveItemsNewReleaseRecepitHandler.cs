using Application.Abstractions;
using Application.Operations.ReceiveItemsNewReleaseRecepit.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dtos;

namespace Application.Operations.ReceiveItemsNewReleaseRecepit.QueryHandlers
{
    public class GetAllReceiveItemsNewReleaseRecepitHandler : IRequestHandler<GetAllReceiveItemsNewReleaseRecepit, ICollection<ReceiveItemsNewReleaseRecepitDto>>
    {
        private readonly IReceiveItemsNewReleaseRecepitRepository _receiveItemsNewReleaseRecepitRepository;

        public GetAllReceiveItemsNewReleaseRecepitHandler(IReceiveItemsNewReleaseRecepitRepository receiveItemsNewReleaseRecepitRepository)
        {
            _receiveItemsNewReleaseRecepitRepository = receiveItemsNewReleaseRecepitRepository;
        }

        public async Task<ICollection<ReceiveItemsNewReleaseRecepitDto>> Handle(GetAllReceiveItemsNewReleaseRecepit request, CancellationToken cancellationToken)
        {
            var receiveItemsNewReleaseRecepitDto =
                  (from ri in await _receiveItemsNewReleaseRecepitRepository.GetAll()

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
                   }).ToList<ReceiveItemsNewReleaseRecepitDto>();

            return receiveItemsNewReleaseRecepitDto;
        }
    }
}
