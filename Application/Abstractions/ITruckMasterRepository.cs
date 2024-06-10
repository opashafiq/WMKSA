using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface ITruckMasterRepository
    {
        Task<ICollection<Domain.Entities.TruckMaster>> GetAll();

        Task<Domain.Entities.TruckMaster> GetTruckMasterById(int truckMasterId);

        Task<Domain.Entities.TruckMaster> AddTruckMaster(Domain.Entities.TruckMaster toCreate);

        Task<Domain.Entities.TruckMaster> UpdateTruckMaster(Domain.Entities.TruckMaster toUpdate);

        Task<Domain.Entities.TruckMaster> DeleteTruckMaster(int truckMasterId);
    }
}
