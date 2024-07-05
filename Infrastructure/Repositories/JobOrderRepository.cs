using Application.Abstractions;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class JobOrderRepository : IJobOrderRepository
    {
        private readonly ApplicationDBContext _context;

        public JobOrderRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<JobOrder> AddJobOrder(JobOrder toCreate)
        {
            _context.JobOrder.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<JobOrder> DeleteJobOrder(int personId)
        {
            var jobOrder = _context.JobOrder
                .FirstOrDefault(p => p.Id == personId);

            if (jobOrder is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.JobOrder.Remove(jobOrder);

            await _context.SaveChangesAsync();
            return jobOrder;

        }



        public async Task<ICollection<JobOrder>> GetAll()
        {
            return await _context.JobOrder.ToListAsync();
        }

        public async Task<JobOrder> GetJobOrderById(int jobOrderId)
        {
            return await _context.JobOrder.FirstOrDefaultAsync(p => p.Id == jobOrderId)?? new JobOrder();
        }        
        
        public async Task<ICollection<JobOrder>> GetJobOrderByCustomerMasterId(long customerMasterId)
        {
            return await _context.JobOrder.Where(p => p.CustomerMasterId == customerMasterId).ToListAsync();
        }

        public async Task<JobOrder> UpdateJobOrder(JobOrder toUpdate )
        {
            _context.JobOrder.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
