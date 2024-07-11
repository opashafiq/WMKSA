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
    public class RecItemMasterRepository : IRecItemMasterRepository
    {
        private readonly ApplicationDBContext _context;

        public RecItemMasterRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<RecItemMaster> AddRecItemMaster(RecItemMaster toCreate)
        {
            _context.RecItemMaster.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<RecItemMaster> DeleteRecItemMaster(int personId)
        {
            var recItemMaster = _context.RecItemMaster
                .FirstOrDefault(p => p.Id == personId);

            if (recItemMaster is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.RecItemMaster.Remove(recItemMaster);

            await _context.SaveChangesAsync();
            return recItemMaster;

        }



        public async Task<ICollection<RecItemMaster>> GetAll()
        {
            return await _context.RecItemMaster.ToListAsync();
        }

        public async Task<RecItemMaster> GetRecItemMasterById(int recItemMasterId)
        {
            return await _context.RecItemMaster.FirstOrDefaultAsync(p => p.Id == recItemMasterId)??new RecItemMaster();
        }

        public async Task<RecItemMaster> UpdateRecItemMaster(RecItemMaster toUpdate )
        {
            _context.RecItemMaster.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
