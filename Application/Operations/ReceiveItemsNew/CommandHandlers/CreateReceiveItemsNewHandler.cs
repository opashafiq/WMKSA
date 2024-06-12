using Application.Abstractions;
using Application.Operations.ReceiveItemsNew.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNew.CommandHandlers
{
    public class CreateReceiveItemsNewHandler : IRequestHandler<CreateReceiveItemsNew, Domain.Entities.ReceiveItemsNew>
    {
        private readonly IReceiveItemsNewRepository _receiveItemsNewRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateReceiveItemsNewHandler(IReceiveItemsNewRepository receiveItemsNewRepository, IMapper mapper)
        {
            _receiveItemsNewRepository = receiveItemsNewRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.ReceiveItemsNew> IRequestHandler<CreateReceiveItemsNew, Domain.Entities.ReceiveItemsNew>.Handle(CreateReceiveItemsNew request, CancellationToken cancellationToken)
        {

            var receiveItemsNew = _mapper.Map<Domain.Entities.ReceiveItemsNew>(request);

            return await _receiveItemsNewRepository.AddReceiveItemsNew(receiveItemsNew);
        }
    }
}
