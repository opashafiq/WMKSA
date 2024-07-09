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
        private readonly IJobOrderRepository _jobOrderRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UpdateReceiveItemsNewHandler(IReceiveItemsNewRepository receiveItemsNewRepository,
            IJobOrderRepository jobOrderRepository,
            IMapper mapper)
        {
            _receiveItemsNewRepository = receiveItemsNewRepository;
            _jobOrderRepository = jobOrderRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.ReceiveItemsNew> IRequestHandler<UpdateReceiveItemsNew, Domain.Entities.ReceiveItemsNew>.Handle(UpdateReceiveItemsNew request, CancellationToken cancellationToken)
        {

            var receiveItemsNew = _mapper.Map<Domain.Entities.ReceiveItemsNew>(request);

            //If Release Qty > 0 update job status to 2 (open)
            //If Release Qty = Qty update job status to 3 (close)

            if(request.RelasedQty!=null & request.RelasedQty > 0)
            {
                if(request.RelasedQty > request.Qty)
                {
                    throw new Exception("Release Quantity Can not be greater than Receive Quantity..");
                }
                var jobOrder = await _jobOrderRepository.GetJobOrderById((long)request.JobOrderId);
                if(request.RelasedQty< request.Qty)
                {
                    jobOrder.JobStatus = 2;
                    _jobOrderRepository.UpdateJobOrder(jobOrder);
                }
                else
                {
                    jobOrder.JobStatus = 3;
                    _jobOrderRepository.UpdateJobOrder(jobOrder);
                }

            }

            return await _receiveItemsNewRepository.UpdateReceiveItemsNew(receiveItemsNew);
        }
    }
}
