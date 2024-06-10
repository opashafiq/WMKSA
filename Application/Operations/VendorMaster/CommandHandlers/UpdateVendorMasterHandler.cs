using Application.Abstractions;
using Application.Operations.VendorMaster.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.VendorMaster.CommandHandlers
{
    public class UpdateVendorMasterHandler : IRequestHandler<UpdateVendorMaster, Domain.Entities.VendorMaster>
    {
        private readonly IVendorMasterRepository _vendorMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UpdateVendorMasterHandler(IVendorMasterRepository vendorMasterRepository, IMapper mapper)
        {
            _vendorMasterRepository = vendorMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.VendorMaster> IRequestHandler<UpdateVendorMaster, Domain.Entities.VendorMaster>.Handle(UpdateVendorMaster request, CancellationToken cancellationToken)
        {

            var vendorMaster = _mapper.Map<Domain.Entities.VendorMaster>(request);
            return await _vendorMasterRepository.UpdateVendorMaster(vendorMaster);
        }
    }
}
