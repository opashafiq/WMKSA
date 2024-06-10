using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface IDriverMasterRepository
    {
        Task<ICollection<Domain.Entities.DriverMaster>> GetAll();

        Task<Domain.Entities.DriverMaster> GetDriverMasterById(int driverMasterId);

        Task<Domain.Entities.DriverMaster> AddDriverMaster(Domain.Entities.DriverMaster toCreate);

        Task<Domain.Entities.DriverMaster> UpdateDriverMaster(Domain.Entities.DriverMaster toUpdate);

        Task<Domain.Entities.DriverMaster> DeleteDriverMaster(int driverMasterId);
    }
}
