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
    public class CreateJobOrderHandler : IRequestHandler<CreateJobOrder, Domain.Entities.JobOrder>
    {
        private readonly IJobOrderRepository _jobOrderRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateJobOrderHandler(IJobOrderRepository jobOrderRepository, IMapper mapper)
        {
            _jobOrderRepository = jobOrderRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.JobOrder> IRequestHandler<CreateJobOrder, Domain.Entities.JobOrder>.Handle(CreateJobOrder request, CancellationToken cancellationToken)
        {

            var jobOrder = _mapper.Map<Domain.Entities.JobOrder>(request);

            return await _jobOrderRepository.AddJobOrder(jobOrder);
        }
    }
}
