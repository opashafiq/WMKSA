using Application.Abstractions;
using Application.Operations.ReceiveItemsNewDetail.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewDetail.CommandHandlers
{
    public class DeleteReceiveItemsNewDetailHandler : IRequestHandler<DeleteReceiveItemsNewDetail, Domain.Entities.ReceiveItemsNewDetail>
    {
        private readonly IReceiveItemsNewDetailRepository _receiveItemsNewDetailRepository;


        public DeleteReceiveItemsNewDetailHandler(IReceiveItemsNewDetailRepository receiveItemsNewDetailsRepository)
        {
            _receiveItemsNewDetailRepository = receiveItemsNewDetailsRepository;
        }

        async Task<Domain.Entities.ReceiveItemsNewDetail> IRequestHandler<DeleteReceiveItemsNewDetail, Domain.Entities.ReceiveItemsNewDetail>.Handle(DeleteReceiveItemsNewDetail request, CancellationToken cancellationToken)
        {
            return await _receiveItemsNewDetailRepository.DeleteReceiveItemsNewDetail(request.Id);

        }
    }
}
