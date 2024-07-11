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
    public class UnitMasterRepository : IUnitMasterRepository
    {
        private readonly ApplicationDBContext _context;

        public UnitMasterRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<UnitMaster> AddUnitMaster(UnitMaster toCreate)
        {
            _context.UnitMaster.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<UnitMaster> DeleteUnitMaster(int personId)
        {
            var unitMaster = _context.UnitMaster
                .FirstOrDefault(p => p.Id == personId);

            if (unitMaster is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.UnitMaster.Remove(unitMaster);

            await _context.SaveChangesAsync();
            return unitMaster;

        }



        public async Task<ICollection<UnitMaster>> GetAll()
        {
            return await _context.UnitMaster.ToListAsync();
        }

        public async Task<UnitMaster> GetUnitMasterById(int unitMasterId)
        {
            return await _context.UnitMaster.FirstOrDefaultAsync(p => p.Id == unitMasterId)??new UnitMaster();
        }

        public async Task<UnitMaster> UpdateUnitMaster(UnitMaster toUpdate )
        {
            _context.UnitMaster.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
