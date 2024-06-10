using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface IPackageMasterRepository
    {
        Task<ICollection<Domain.Entities.PackageMaster>> GetAll();

        Task<Domain.Entities.PackageMaster> GetPackageMasterById(int packageMasterId);

        Task<Domain.Entities.PackageMaster> AddPackageMaster(Domain.Entities.PackageMaster toCreate);

        Task<Domain.Entities.PackageMaster> UpdatePackageMaster(Domain.Entities.PackageMaster toUpdate);

        Task<Domain.Entities.PackageMaster> DeletePackageMaster(int packageMasterId);
    }
}
