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
    public class TruckMasterRepository : ITruckMasterRepository
    {
        private readonly ApplicationDBContext _context;

        public TruckMasterRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<TruckMaster> AddTruckMaster(TruckMaster toCreate)
        {
            _context.TruckMaster.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<TruckMaster> DeleteTruckMaster(int personId)
        {
            var truckMaster = _context.TruckMaster
                .FirstOrDefault(p => p.Id == personId);

            if (truckMaster is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.TruckMaster.Remove(truckMaster);

            await _context.SaveChangesAsync();
            return truckMaster;

        }



        public async Task<ICollection<TruckMaster>> GetAll()
        {
            return await _context.TruckMaster.ToListAsync();
        }

        public async Task<TruckMaster> GetTruckMasterById(int truckMasterId)
        {
            return await _context.TruckMaster.FirstOrDefaultAsync(p => p.Id == truckMasterId) ?? new TruckMaster();
        }        
        
        public async Task<TruckMaster> GetTruckMasterByTruckNo(string truckNo)
        {
            return await _context.TruckMaster.FirstOrDefaultAsync(p => p.TruckNo == truckNo)?? new TruckMaster();
        }

        public async Task<TruckMaster> UpdateTruckMaster(TruckMaster toUpdate )
        {
            _context.TruckMaster.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
