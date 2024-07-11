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
    public class SubCustomerMasterRepository : ISubCustomerMasterRepository
    {
        private readonly ApplicationDBContext _context;

        public SubCustomerMasterRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<SubCustomerMaster> AddSubCustomerMaster(SubCustomerMaster toCreate)
        {
            _context.SubCustomerMaster.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<SubCustomerMaster> DeleteSubCustomerMaster(int subCustomerMasterId)
        {
            var subCustomerMaster = _context.SubCustomerMaster
                .FirstOrDefault(p => p.Id == subCustomerMasterId);

            if (subCustomerMaster is null)
            {
                throw new Exception("Nothing Found For Deletion");
            }

            _context.SubCustomerMaster.Remove(subCustomerMaster);

            await _context.SaveChangesAsync();
            return subCustomerMaster;

        }

        public async Task<ICollection<SubCustomerMaster>> GetAll()
        {
            return await _context.SubCustomerMaster.ToListAsync();
        }

        public async Task<SubCustomerMaster> GetSubCustomerMasterById(int subCustomerMasterId)
        {
            return await _context.SubCustomerMaster.FirstOrDefaultAsync(p => p.Id == subCustomerMasterId)?? new SubCustomerMaster();
        }

        public async Task<SubCustomerMaster> UpdateSubCustomerMaster(SubCustomerMaster toUpdate )
        {
            _context.SubCustomerMaster.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }


    }
}
