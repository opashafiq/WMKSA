using Application.Abstractions;
using Application.Operations.VendorMaster.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.VendorMaster.CommandHandlers
{
    public class DeleteVendorMasterHandler : IRequestHandler<DeleteVendorMaster, Domain.Entities.VendorMaster>
    {
        private readonly IVendorMasterRepository _vendorMasterRepository;


        public DeleteVendorMasterHandler(IVendorMasterRepository vendorMasterRepository)
        {
            _vendorMasterRepository = vendorMasterRepository;
        }

        async Task<Domain.Entities.VendorMaster> IRequestHandler<DeleteVendorMaster, Domain.Entities.VendorMaster>.Handle(DeleteVendorMaster request, CancellationToken cancellationToken)
        {
            return await _vendorMasterRepository.DeleteVendorMaster(request.Id);

        }
    }
}
