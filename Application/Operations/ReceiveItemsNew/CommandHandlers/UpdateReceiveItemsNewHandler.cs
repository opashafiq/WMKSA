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
    public class UpdateReceiveItemsNewHandler : IRequestHandler<UpdateReceiveItemsNew, Domain.Entities.ReceiveItemsNew>
    {
        private readonly IReceiveItemsNewRepository _receiveItemsNewRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UpdateReceiveItemsNewHandler(IReceiveItemsNewRepository receiveItemsNewRepository, IMapper mapper)
        {
            _receiveItemsNewRepository = receiveItemsNewRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.ReceiveItemsNew> IRequestHandler<UpdateReceiveItemsNew, Domain.Entities.ReceiveItemsNew>.Handle(UpdateReceiveItemsNew request, CancellationToken cancellationToken)
        {

            var receiveItemsNew = _mapper.Map<Domain.Entities.ReceiveItemsNew>(request);
            return await _receiveItemsNewRepository.UpdateReceiveItemsNew(receiveItemsNew);
        }
    }
}
