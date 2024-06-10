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
    public class GetAllCustomerMasterHandler : IRequestHandler<GetAllCustomerMaster, ICollection<Domain.Entities.CustomerMaster>>
    {
        private readonly ICustomerMasterRepository _customerMasterRepository;

        public GetAllCustomerMasterHandler(ICustomerMasterRepository customerMasterRepository)
        {
            _customerMasterRepository = customerMasterRepository;
        }

        public async Task<ICollection<Domain.Entities.CustomerMaster>> Handle(GetAllCustomerMaster request, CancellationToken cancellationToken)
        {
            return await _customerMasterRepository.GetAll();
        }
    }
}
