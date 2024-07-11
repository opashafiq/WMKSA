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
    public class PackageMasterRepository : IPackageMasterRepository
    {
        private readonly ApplicationDBContext _context;

        public PackageMasterRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<PackageMaster> AddPackageMaster(PackageMaster toCreate)
        {
            _context.PackageMaster.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<PackageMaster> DeletePackageMaster(int personId)
        {
            var packageMaster = _context.PackageMaster
                .FirstOrDefault(p => p.Id == personId);

            if (packageMaster is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.PackageMaster.Remove(packageMaster);

            await _context.SaveChangesAsync();
            return packageMaster;

        }



        public async Task<ICollection<PackageMaster>> GetAll()
        {
            return await _context.PackageMaster.ToListAsync();
        }

        public async Task<PackageMaster> GetPackageMasterById(int packageMasterId)
        {
            return await _context.PackageMaster.FirstOrDefaultAsync(p => p.Id == packageMasterId)?? new PackageMaster();
        }

        public async Task<PackageMaster> UpdatePackageMaster(PackageMaster toUpdate )
        {
            _context.PackageMaster.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
