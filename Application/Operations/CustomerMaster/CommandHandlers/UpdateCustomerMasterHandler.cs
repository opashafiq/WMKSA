using Application.Abstractions;
using Application.Operations.CustomerMaster.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.CustomerMaster.CommandHandlers
{
    public class UpdateCustomerMasterHandler : IRequestHandler<UpdateCustomerMaster, Domain.Entities.CustomerMaster>
    {
        private readonly ICustomerMasterRepository _customerMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UpdateCustomerMasterHandler(ICustomerMasterRepository customerMasterRepository, IMapper mapper)
        {
            _customerMasterRepository = customerMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.CustomerMaster> IRequestHandler<UpdateCustomerMaster, Domain.Entities.CustomerMaster>.Handle(UpdateCustomerMaster request, CancellationToken cancellationToken)
        {

            var customerMaster = _mapper.Map<Domain.Entities.CustomerMaster>(request);
            return await _customerMasterRepository.UpdateCustomerMaster(customerMaster);
        }
    }
}
