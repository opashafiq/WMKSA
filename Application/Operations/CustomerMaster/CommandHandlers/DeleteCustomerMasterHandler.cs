using Application.Abstractions;
using Application.Operations.CustomerMaster.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.CustomerMaster.CommandHandlers
{
    public class DeleteCustomerMasterHandler : IRequestHandler<DeleteCustomerMaster, Domain.Entities.CustomerMaster>
    {
        private readonly ICustomerMasterRepository _customerMasterRepository;


        public DeleteCustomerMasterHandler(ICustomerMasterRepository customerMasterRepository)
        {
            _customerMasterRepository = customerMasterRepository;
        }

        async Task<Domain.Entities.CustomerMaster> IRequestHandler<DeleteCustomerMaster, Domain.Entities.CustomerMaster>.Handle(DeleteCustomerMaster request, CancellationToken cancellationToken)
        {
            return await _customerMasterRepository.DeleteCustomerMaster(request.Id);

        }
    }
}
