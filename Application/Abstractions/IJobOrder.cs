using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface IJobOrderRepository
    {
        Task<ICollection<Domain.Entities.JobOrder>> GetAll();

        Task<Domain.Entities.JobOrder> GetJobOrderById(long jobOrderId);
        Task<ICollection<Domain.Entities.JobOrder>> GetJobOrderByCustomerMasterId(long customerMasterId);

        Task<Domain.Entities.JobOrder> AddJobOrder(Domain.Entities.JobOrder toCreate);

        Task<Domain.Entities.JobOrder> UpdateJobOrder(Domain.Entities.JobOrder toUpdate);

        Task<Domain.Entities.JobOrder> DeleteJobOrder(int jobOrderId);
    }
}
