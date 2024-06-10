using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface IVendorMasterRepository
    {
        Task<ICollection<Domain.Entities.VendorMaster>> GetAll();

        Task<Domain.Entities.VendorMaster> GetVendorMasterById(int vendorMasterId);

        Task<Domain.Entities.VendorMaster> AddVendorMaster(Domain.Entities.VendorMaster toCreate);

        Task<Domain.Entities.VendorMaster> UpdateVendorMaster(Domain.Entities.VendorMaster toUpdate);

        Task<Domain.Entities.VendorMaster> DeleteVendorMaster(int vendorMasterId);
    }
}
