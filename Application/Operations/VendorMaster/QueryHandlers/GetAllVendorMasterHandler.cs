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
    public class GetAllVendorMasterHandler : IRequestHandler<GetAllVendorMaster, ICollection<Domain.Entities.VendorMaster>>
    {
        private readonly IVendorMasterRepository _vendorMasterRepository;

        public GetAllVendorMasterHandler(IVendorMasterRepository vendorMasterRepository)
        {
            _vendorMasterRepository = vendorMasterRepository;
        }

        public async Task<ICollection<Domain.Entities.VendorMaster>> Handle(GetAllVendorMaster request, CancellationToken cancellationToken)
        {
            return await _vendorMasterRepository.GetAll();
        }
    }
}
