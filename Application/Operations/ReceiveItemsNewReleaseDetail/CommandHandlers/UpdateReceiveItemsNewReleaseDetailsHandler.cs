using Application.Abstractions;
using Application.Operations.ReceiveItemsNewReleaseDetail.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseDetail.CommandHandlers
{
    public class UpdateReceiveItemsNewReleaseDetailHandler : IRequestHandler<UpdateReceiveItemsNewReleaseDetail, Domain.Entities.ReceiveItemsNewReleaseDetail>
    {
        private readonly IReceiveItemsNewReleaseDetailRepository _receiveItemsNewReleaseDetailRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UpdateReceiveItemsNewReleaseDetailHandler(IReceiveItemsNewReleaseDetailRepository receiveItemsNewReleaseDetailRepository, IMapper mapper)
        {
            _receiveItemsNewReleaseDetailRepository = receiveItemsNewReleaseDetailRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.ReceiveItemsNewReleaseDetail> IRequestHandler<UpdateReceiveItemsNewReleaseDetail, Domain.Entities.ReceiveItemsNewReleaseDetail>.Handle(UpdateReceiveItemsNewReleaseDetail request, CancellationToken cancellationToken)
        {

            var receiveItemsNewReleaseDetails = _mapper.Map<Domain.Entities.ReceiveItemsNewReleaseDetail>(request);
            return await _receiveItemsNewReleaseDetailRepository.UpdateReceiveItemsNewReleaseDetail(receiveItemsNewReleaseDetails);
        }
    }
}
