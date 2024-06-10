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
    public class DriverMasterRepository : IDriverMasterRepository
    {
        private readonly ApplicationDBContext _context;

        public DriverMasterRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<DriverMaster> AddDriverMaster(DriverMaster toCreate)
        {
            _context.DriverMaster.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<DriverMaster> DeleteDriverMaster(int personId)
        {
            var driverMaster = _context.DriverMaster
                .FirstOrDefault(p => p.Id == personId);

            if (driverMaster is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.DriverMaster.Remove(driverMaster);

            await _context.SaveChangesAsync();
            return driverMaster;

        }



        public async Task<ICollection<DriverMaster>> GetAll()
        {
            return await _context.DriverMaster.ToListAsync();
        }

        public async Task<DriverMaster> GetDriverMasterById(int driverMasterId)
        {
            return await _context.DriverMaster.FirstOrDefaultAsync(p => p.Id == driverMasterId);
        }

        public async Task<DriverMaster> UpdateDriverMaster(DriverMaster toUpdate )
        {
            _context.DriverMaster.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
