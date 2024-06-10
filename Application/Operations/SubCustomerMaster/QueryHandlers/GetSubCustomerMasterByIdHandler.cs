using Application.Abstractions;
using Application.Operations.CustomerMaster.Queries;
using Application.Operations.SubCustomerMaster.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.SubCustomerMaster.QueryHandlers
{
    public class GetSubCustomerMasterByIdHandler : IRequestHandler<GetSubCustomerMasterById, Domain.Entities.SubCustomerMaster>
    {
        private readonly ISubCustomerMasterRepository _subCustomerMasterRepository;

        public GetSubCustomerMasterByIdHandler(ISubCustomerMasterRepository subCustomerMasterRepository)
        {
            _subCustomerMasterRepository = subCustomerMasterRepository;
        }

        public async Task<Domain.Entities.SubCustomerMaster> Handle(GetSubCustomerMasterById request, CancellationToken cancellationToken)
        {
            return await _subCustomerMasterRepository.GetSubCustomerMasterById(request.Id);
        }
    }
}
