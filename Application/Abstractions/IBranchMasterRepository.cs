using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface IBranchMasterRepository
    {
        Task<ICollection<Domain.Entities.BranchMaster>> GetAll();

        Task<Domain.Entities.BranchMaster> GetBranchMasterById(int branchMasterId);

        Task<Domain.Entities.BranchMaster> AddBranchMaster(Domain.Entities.BranchMaster toCreate);

        Task<Domain.Entities.BranchMaster> UpdateBranchMaster(Domain.Entities.BranchMaster toUpdate);

        Task<Domain.Entities.BranchMaster> DeleteBranchMaster(int branchMasterId);
    }
}
