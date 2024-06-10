using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface IUnitMasterRepository
    {
        Task<ICollection<Domain.Entities.UnitMaster>> GetAll();

        Task<Domain.Entities.UnitMaster> GetUnitMasterById(int unitMasterId);

        Task<Domain.Entities.UnitMaster> AddUnitMaster(Domain.Entities.UnitMaster toCreate);

        Task<Domain.Entities.UnitMaster> UpdateUnitMaster(Domain.Entities.UnitMaster toUpdate);

        Task<Domain.Entities.UnitMaster> DeleteUnitMaster(int unitMasterId);
    }
}
