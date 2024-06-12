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
    public class CreateReceiveItemsNewReleaseDetailHandler : IRequestHandler<CreateReceiveItemsNewReleaseDetail, Domain.Entities.ReceiveItemsNewReleaseDetail>
    {
        private readonly IReceiveItemsNewReleaseDetailRepository _receiveItemsNewReleaseDetailRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateReceiveItemsNewReleaseDetailHandler(IReceiveItemsNewReleaseDetailRepository receiveItemsNewReleaseDetailRepository, IMapper mapper)
        {
            _receiveItemsNewReleaseDetailRepository = receiveItemsNewReleaseDetailRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.ReceiveItemsNewReleaseDetail> IRequestHandler<CreateReceiveItemsNewReleaseDetail, Domain.Entities.ReceiveItemsNewReleaseDetail>.Handle(CreateReceiveItemsNewReleaseDetail request, CancellationToken cancellationToken)
        {

            var receiveItemsNewReleaseDetails = _mapper.Map<Domain.Entities.ReceiveItemsNewReleaseDetail>(request);

            return await _receiveItemsNewReleaseDetailRepository.AddReceiveItemsNewReleaseDetail(receiveItemsNewReleaseDetails);
        }
    }
}
