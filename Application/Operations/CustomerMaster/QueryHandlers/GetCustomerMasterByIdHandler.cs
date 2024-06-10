using Application.Abstractions;
using Application.Operations.CustomerMaster.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.CustomerMaster.QueryHandlers
{
    public class GetCustomerMasterByIdHandler : IRequestHandler<GetCustomerMasterById, Domain.Entities.CustomerMaster>
    {
        private readonly ICustomerMasterRepository _customerMasterRepository;

        public GetCustomerMasterByIdHandler(ICustomerMasterRepository customerMasterRepository)
        {
            _customerMasterRepository = customerMasterRepository;
        }

        public async Task<Domain.Entities.CustomerMaster> Handle(GetCustomerMasterById request, CancellationToken cancellationToken)
        {
            return await _customerMasterRepository.GetCustomerMasterById(request.Id);
        }
    }
}
