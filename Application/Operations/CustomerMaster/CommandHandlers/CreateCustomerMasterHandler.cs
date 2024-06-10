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
    public class CreateCustomerMasterHandler : IRequestHandler<CreateCustomerMaster, Domain.Entities.CustomerMaster>
    {
        private readonly ICustomerMasterRepository _customerMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateCustomerMasterHandler(ICustomerMasterRepository customerMasterRepository, IMapper mapper)
        {
            _customerMasterRepository = customerMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.CustomerMaster> IRequestHandler<CreateCustomerMaster, Domain.Entities.CustomerMaster>.Handle(CreateCustomerMaster request, CancellationToken cancellationToken)
        {

            var customerMaster = _mapper.Map<Domain.Entities.CustomerMaster>(request);

            return await _customerMasterRepository.AddCustomerMaster(customerMaster);
        }
    }
}
