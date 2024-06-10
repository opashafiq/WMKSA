using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface ISubCustomerMasterRepository
    {
        Task<ICollection<Domain.Entities.SubCustomerMaster>> GetAll();

        Task<Domain.Entities.SubCustomerMaster> GetSubCustomerMasterById(int subCustomerMasterId);

        Task<Domain.Entities.SubCustomerMaster> AddSubCustomerMaster(Domain.Entities.SubCustomerMaster toCreate);

        Task<Domain.Entities.SubCustomerMaster> UpdateSubCustomerMaster(Domain.Entities.SubCustomerMaster toUpdate);

        Task<Domain.Entities.SubCustomerMaster> DeleteSubCustomerMaster(int subCustomerMasterId);
    }
}
