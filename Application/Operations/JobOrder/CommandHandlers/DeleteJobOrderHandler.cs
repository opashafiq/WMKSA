using Application.Abstractions;
using Application.Operations.JobOrder.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.JobOrder.CommandHandlers
{
    public class DeleteJobOrderHandler : IRequestHandler<DeleteJobOrder, Domain.Entities.JobOrder>
    {
        private readonly IJobOrderRepository _jobOrderRepository;


        public DeleteJobOrderHandler(IJobOrderRepository jobOrderRepository)
        {
            _jobOrderRepository = jobOrderRepository;
        }

        async Task<Domain.Entities.JobOrder> IRequestHandler<DeleteJobOrder, Domain.Entities.JobOrder>.Handle(DeleteJobOrder request, CancellationToken cancellationToken)
        {
            return await _jobOrderRepository.DeleteJobOrder(request.Id);

        }
    }
}
