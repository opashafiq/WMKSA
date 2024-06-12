using Application.Abstractions;
using Application.Operations.ReceiveItemsNewRelease.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewRelease.CommandHandlers
{
    public class CreateReceiveItemsNewReleaseHandler : IRequestHandler<CreateReceiveItemsNewRelease, Domain.Entities.ReceiveItemsNewRelease>
    {
        private readonly IReceiveItemsNewReleaseRepository _receiveItemsNewReleaseRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateReceiveItemsNewReleaseHandler(IReceiveItemsNewReleaseRepository receiveItemsNewReleaseRepository, IMapper mapper)
        {
            _receiveItemsNewReleaseRepository = receiveItemsNewReleaseRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.ReceiveItemsNewRelease> IRequestHandler<CreateReceiveItemsNewRelease, Domain.Entities.ReceiveItemsNewRelease>.Handle(CreateReceiveItemsNewRelease request, CancellationToken cancellationToken)
        {

            var receiveItemsNewRelease = _mapper.Map<Domain.Entities.ReceiveItemsNewRelease>(request);

            return await _receiveItemsNewReleaseRepository.AddReceiveItemsNewRelease(receiveItemsNewRelease);
        }
    }
}
