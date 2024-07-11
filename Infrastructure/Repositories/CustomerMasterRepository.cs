using Application.Abstractions;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CustomerMasterRepository : ICustomerMasterRepository
    {
        private readonly ApplicationDBContext _context;

        public CustomerMasterRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<CustomerMaster> AddCustomerMaster(CustomerMaster toCreate)
        {
            _context.CustomerMaster.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<CustomerMaster> DeleteCustomerMaster(int personId)
        {
            var customerMaster = _context.CustomerMaster
                .FirstOrDefault(p => p.Id == personId);

            if (customerMaster is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.CustomerMaster.Remove(customerMaster);

            await _context.SaveChangesAsync();
            return customerMaster;

        }



        public async Task<ICollection<CustomerMaster>> GetAll()
        {
            return await _context.CustomerMaster.ToListAsync();
        }

        public async Task<CustomerMaster> GetCustomerMasterById(long customerMasterId)
        {
            return await _context.CustomerMaster.FirstOrDefaultAsync(p => p.Id == customerMasterId)??new CustomerMaster();
        }

        public async Task<CustomerMaster> UpdateCustomerMaster(CustomerMaster toUpdate )
        {
            _context.CustomerMaster.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
