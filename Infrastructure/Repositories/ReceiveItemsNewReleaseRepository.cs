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
    public class ReceiveItemsNewReleaseRepository : IReceiveItemsNewReleaseRepository
    {
        private readonly ApplicationDBContext _context;

        public ReceiveItemsNewReleaseRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ReceiveItemsNewRelease> AddReceiveItemsNewRelease(ReceiveItemsNewRelease toCreate)
        {
            _context.ReceiveItemsNewRelease.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<ReceiveItemsNewRelease> DeleteReceiveItemsNewRelease(int personId)
        {
            var receiveItemsNewRelease = _context.ReceiveItemsNewRelease
                .FirstOrDefault(p => p.Id == personId);

            if (receiveItemsNewRelease is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.ReceiveItemsNewRelease.Remove(receiveItemsNewRelease);

            await _context.SaveChangesAsync();
            return receiveItemsNewRelease;

        }



        public async Task<ICollection<ReceiveItemsNewRelease>> GetAll()
        {
            return await _context.ReceiveItemsNewRelease.ToListAsync();
        }

        public async Task<ReceiveItemsNewRelease> GetReceiveItemsNewReleaseById(int receiveItemsNewReleaseId)
        {
            return await _context.ReceiveItemsNewRelease.FirstOrDefaultAsync(p => p.Id == receiveItemsNewReleaseId);
        }

        public async Task<ReceiveItemsNewRelease> UpdateReceiveItemsNewRelease(ReceiveItemsNewRelease toUpdate )
        {
            _context.ReceiveItemsNewRelease.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
