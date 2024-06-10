using Application.Abstractions;
using Application.Operations.VendorMaster.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.VendorMaster.QueryHandlers
{
    public class GetVendorMasterByIdHandler : IRequestHandler<GetVendorMasterById, Domain.Entities.VendorMaster>
    {
        private readonly IVendorMasterRepository _vendorMasterRepository;

        public GetVendorMasterByIdHandler(IVendorMasterRepository vendorMasterRepository)
        {
            _vendorMasterRepository = vendorMasterRepository;
        }

        public async Task<Domain.Entities.VendorMaster> Handle(GetVendorMasterById request, CancellationToken cancellationToken)
        {
            return await _vendorMasterRepository.GetVendorMasterById(request.Id);
        }
    }
}
