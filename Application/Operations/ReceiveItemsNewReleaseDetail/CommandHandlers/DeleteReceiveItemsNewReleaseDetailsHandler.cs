using Application.Abstractions;
using Application.Operations.ReceiveItemsNewReleaseDetail.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseDetail.CommandHandlers
{
    public class DeleteReceiveItemsNewReleaseDetailHandler : IRequestHandler<DeleteReceiveItemsNewReleaseDetail, Domain.Entities.ReceiveItemsNewReleaseDetail>
    {
        private readonly IReceiveItemsNewReleaseDetailRepository _receiveItemsNewReleaseDetailRepository;


        public DeleteReceiveItemsNewReleaseDetailHandler(IReceiveItemsNewReleaseDetailRepository receiveItemsNewReleaseDetailRepository)
        {
            _receiveItemsNewReleaseDetailRepository = receiveItemsNewReleaseDetailRepository;
        }

        async Task<Domain.Entities.ReceiveItemsNewReleaseDetail> IRequestHandler<DeleteReceiveItemsNewReleaseDetail, Domain.Entities.ReceiveItemsNewReleaseDetail>.Handle(DeleteReceiveItemsNewReleaseDetail request, CancellationToken cancellationToken)
        {
            return await _receiveItemsNewReleaseDetailRepository.DeleteReceiveItemsNewReleaseDetail(request.Id);

        }
    }
}
