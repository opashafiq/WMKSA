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
    public class GetAllSubCustomerMasterHandler : IRequestHandler<GetAllSubCustomerMaster, ICollection<Domain.Entities.SubCustomerMaster>>
    {
        private readonly ISubCustomerMasterRepository _subCustomerMasterRepository;

        public GetAllSubCustomerMasterHandler(ISubCustomerMasterRepository subCustomerMasterRepository)
        {
            _subCustomerMasterRepository = subCustomerMasterRepository;
        }

        public async Task<ICollection<Domain.Entities.SubCustomerMaster>> Handle(GetAllSubCustomerMaster request, CancellationToken cancellationToken)
        {
            return await _subCustomerMasterRepository.GetAll();
        }
    }
}
