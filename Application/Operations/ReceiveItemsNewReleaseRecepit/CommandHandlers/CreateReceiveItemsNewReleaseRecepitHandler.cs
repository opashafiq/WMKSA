using Application.Abstractions;
using Application.Operations.ReceiveItemsNewReleaseRecepit.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseRecepit.CommandHandlers
{
    public class CreateReceiveItemsNewReleaseRecepitHandler : IRequestHandler<CreateReceiveItemsNewReleaseRecepit, Domain.Entities.ReceiveItemsNewReleaseRecepit>
    {
        private readonly IReceiveItemsNewReleaseRecepitRepository _receiveItemsNewReleaseRecepitRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateReceiveItemsNewReleaseRecepitHandler(IReceiveItemsNewReleaseRecepitRepository receiveItemsNewReleaseRecepitRepository, IMapper mapper)
        {
            _receiveItemsNewReleaseRecepitRepository = receiveItemsNewReleaseRecepitRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.ReceiveItemsNewReleaseRecepit> IRequestHandler<CreateReceiveItemsNewReleaseRecepit, Domain.Entities.ReceiveItemsNewReleaseRecepit>.Handle(CreateReceiveItemsNewReleaseRecepit request, CancellationToken cancellationToken)
        {
            var receiveItemsNewReleaseRecepit = _mapper.Map<Domain.Entities.ReceiveItemsNewReleaseRecepit>(request);
            return await _receiveItemsNewReleaseRecepitRepository.AddReceiveItemsNewReleaseRecepit(receiveItemsNewReleaseRecepit);
        }

    }
}
