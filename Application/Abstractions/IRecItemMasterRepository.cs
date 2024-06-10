using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface IRecItemMasterRepository
    {
        Task<ICollection<Domain.Entities.RecItemMaster>> GetAll();

        Task<Domain.Entities.RecItemMaster> GetRecItemMasterById(int recItemMasterId);

        Task<Domain.Entities.RecItemMaster> AddRecItemMaster(Domain.Entities.RecItemMaster toCreate);

        Task<Domain.Entities.RecItemMaster> UpdateRecItemMaster(Domain.Entities.RecItemMaster toUpdate);

        Task<Domain.Entities.RecItemMaster> DeleteRecItemMaster(int recItemMasterId);
    }
}
