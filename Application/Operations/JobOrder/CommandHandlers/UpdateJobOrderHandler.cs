using Application.Abstractions;
using Application.Operations.JobOrder.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.JobOrder.CommandHandlers
{
    public class UpdateJobOrderHandler : IRequestHandler<UpdateJobOrder, Domain.Entities.JobOrder>
    {
        private readonly IJobOrderRepository _jobOrderRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UpdateJobOrderHandler(IJobOrderRepository jobOrderRepository, IMapper mapper)
        {
            _jobOrderRepository = jobOrderRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.JobOrder> IRequestHandler<UpdateJobOrder, Domain.Entities.JobOrder>.Handle(UpdateJobOrder request, CancellationToken cancellationToken)
        {

            var jobOrder = _mapper.Map<Domain.Entities.JobOrder>(request);
            return await _jobOrderRepository.UpdateJobOrder(jobOrder);
        }
    }
}
