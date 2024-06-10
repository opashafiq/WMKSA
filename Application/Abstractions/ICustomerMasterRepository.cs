using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface ICustomerMasterRepository
    {
        Task<ICollection<Domain.Entities.CustomerMaster>> GetAll();

        Task<Domain.Entities.CustomerMaster> GetCustomerMasterById(int customerMasterId);

        Task<Domain.Entities.CustomerMaster> AddCustomerMaster(Domain.Entities.CustomerMaster toCreate);

        Task<Domain.Entities.CustomerMaster> UpdateCustomerMaster(Domain.Entities.CustomerMaster toUpdate);

        Task<Domain.Entities.CustomerMaster> DeleteCustomerMaster(int customerMasterId);
    }
}
