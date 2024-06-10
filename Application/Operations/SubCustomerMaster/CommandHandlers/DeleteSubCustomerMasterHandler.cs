using Application.Abstractions;
using Application.Operations.CustomerMaster.Commands;
using Application.Operations.Person.Commands;
using Application.Operations.SubCustomerMaster.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.SubCustomerMaster.CommandHandlers
{
    public class DeleteSubCustomerMasterHandler : IRequestHandler<DeleteSubCustomerMaster, Domain.Entities.SubCustomerMaster>
    {
        private readonly ISubCustomerMasterRepository _subCustomerMasterRepository;


        public DeleteSubCustomerMasterHandler(ISubCustomerMasterRepository subCustomerMasterRepository)
        {
            _subCustomerMasterRepository = subCustomerMasterRepository;
        }

        async Task<Domain.Entities.SubCustomerMaster> IRequestHandler<DeleteSubCustomerMaster, Domain.Entities.SubCustomerMaster>.Handle(DeleteSubCustomerMaster request, CancellationToken cancellationToken)
        {
            return await _subCustomerMasterRepository.DeleteSubCustomerMaster(request.Id);

        }
    }
}
