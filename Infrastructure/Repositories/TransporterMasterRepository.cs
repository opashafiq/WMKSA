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
    public class TransporterMasterRepository : ITransporterMasterRepository
    {
        private readonly ApplicationDBContext _context;

        public TransporterMasterRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<TransporterMaster> AddTransporterMaster(TransporterMaster toCreate)
        {
            _context.TransporterMaster.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<TransporterMaster> DeleteTransporterMaster(int personId)
        {
            var transporterMaster = _context.TransporterMaster
                .FirstOrDefault(p => p.Id == personId);

            if (transporterMaster is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.TransporterMaster.Remove(transporterMaster);

            await _context.SaveChangesAsync();
            return transporterMaster;

        }



        public async Task<ICollection<TransporterMaster>> GetAll()
        {
            return await _context.TransporterMaster.ToListAsync();
        }

        public async Task<TransporterMaster> GetTransporterMasterById(int transporterMasterId)
        {
            return await _context.TransporterMaster.FirstOrDefaultAsync(p => p.Id == transporterMasterId);
        }

        public async Task<TransporterMaster> UpdateTransporterMaster(TransporterMaster toUpdate )
        {
            _context.TransporterMaster.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
