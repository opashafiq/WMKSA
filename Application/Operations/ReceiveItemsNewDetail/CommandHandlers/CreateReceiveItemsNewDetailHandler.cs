using Application.Abstractions;
using Application.Operations.ReceiveItemsNewDetail.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Operations.ReceiveItemsNewDetail.CommandHandlers
{
    public class CreateReceiveItemsNewDetailHandler : IRequestHandler<CreateReceiveItemsNewDetail, Domain.Entities.ReceiveItemsNewDetail>
    {
        private readonly IReceiveItemsNewDetailRepository _receiveItemsNewDetailRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateReceiveItemsNewDetailHandler(IReceiveItemsNewDetailRepository receiveItemsNewDetailRepository, IMapper mapper)
        {
            _receiveItemsNewDetailRepository = receiveItemsNewDetailRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.ReceiveItemsNewDetail> IRequestHandler<CreateReceiveItemsNewDetail, Domain.Entities.ReceiveItemsNewDetail>.Handle(CreateReceiveItemsNewDetail request, CancellationToken cancellationToken)
        {

            var receiveItemsNewDetails = _mapper.Map<Domain.Entities.ReceiveItemsNewDetail>(request);

            return await _receiveItemsNewDetailRepository.AddReceiveItemsNewDetail(receiveItemsNewDetails);
        }
    }
}
