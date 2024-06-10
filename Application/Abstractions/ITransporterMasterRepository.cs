using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface ITransporterMasterRepository
    {
        Task<ICollection<Domain.Entities.TransporterMaster>> GetAll();

        Task<Domain.Entities.TransporterMaster> GetTransporterMasterById(int transporterMasterId);

        Task<Domain.Entities.TransporterMaster> AddTransporterMaster(Domain.Entities.TransporterMaster toCreate);

        Task<Domain.Entities.TransporterMaster> UpdateTransporterMaster(Domain.Entities.TransporterMaster toUpdate);

        Task<Domain.Entities.TransporterMaster> DeleteTransporterMaster(int transporterMasterId);
    }
}
