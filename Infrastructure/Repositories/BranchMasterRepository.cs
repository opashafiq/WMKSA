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
    public class BranchMasterRepository : IBranchMasterRepository
    {
        private readonly ApplicationDBContext _context;

        public BranchMasterRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<BranchMaster> AddBranchMaster(BranchMaster toCreate)
        {
            _context.BranchMaster.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<BranchMaster> DeleteBranchMaster(int personId)
        {
            var branchMaster = _context.BranchMaster
                .FirstOrDefault(p => p.Id == personId);

            if (branchMaster is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.BranchMaster.Remove(branchMaster);

            await _context.SaveChangesAsync();
            return branchMaster;

        }



        public async Task<ICollection<BranchMaster>> GetAll()
        {
            return await _context.BranchMaster.ToListAsync();
        }

        public async Task<BranchMaster> GetBranchMasterById(int branchMasterId)
        {
            return await _context.BranchMaster.FirstOrDefaultAsync(p => p.Id == branchMasterId);
        }

        public async Task<BranchMaster> UpdateBranchMaster(BranchMaster toUpdate )
        {
            _context.BranchMaster.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
