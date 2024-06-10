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
    public class VendorMasterRepository : IVendorMasterRepository
    {
        private readonly ApplicationDBContext _context;

        public VendorMasterRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<VendorMaster> AddVendorMaster(VendorMaster toCreate)
        {
            _context.VendorMaster.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<VendorMaster> DeleteVendorMaster(int personId)
        {
            var vendorMaster = _context.VendorMaster
                .FirstOrDefault(p => p.Id == personId);

            if (vendorMaster is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.VendorMaster.Remove(vendorMaster);

            await _context.SaveChangesAsync();
            return vendorMaster;

        }



        public async Task<ICollection<VendorMaster>> GetAll()
        {
            return await _context.VendorMaster.ToListAsync();
        }

        public async Task<VendorMaster> GetVendorMasterById(int vendorMasterId)
        {
            return await _context.VendorMaster.FirstOrDefaultAsync(p => p.Id == vendorMasterId);
        }

        public async Task<VendorMaster> UpdateVendorMaster(VendorMaster toUpdate )
        {
            _context.VendorMaster.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
