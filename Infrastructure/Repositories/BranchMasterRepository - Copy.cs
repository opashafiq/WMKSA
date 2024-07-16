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
    public class ReceiveItemsNewReleaseRecepitRepository : IReceiveItemsNewReleaseRecepitRepository
    {
        private readonly ApplicationDBContext _context;

        public ReceiveItemsNewReleaseRecepitRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ReceiveItemsNewReleaseRecepit> AddReceiveItemsNewReleaseRecepit(ReceiveItemsNewReleaseRecepit toCreate)
        {
            _context.ReceiveItemsNewReleaseRecepit.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<ReceiveItemsNewReleaseRecepit> DeleteReceiveItemsNewReleaseRecepit(int receiveItemsNewReleaseRecepitId)
        {
            var receiveItemsNewReleaseRecepit = _context.ReceiveItemsNewReleaseRecepit
                .FirstOrDefault(p => p.Id == receiveItemsNewReleaseRecepitId);

            if (receiveItemsNewReleaseRecepit is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.ReceiveItemsNewReleaseRecepit.Remove(receiveItemsNewReleaseRecepit);

            await _context.SaveChangesAsync();
            return receiveItemsNewReleaseRecepit;

        }



        public async Task<ICollection<ReceiveItemsNewReleaseRecepit>> GetAll()
        {
            return await _context.ReceiveItemsNewReleaseRecepit.ToListAsync();
        }

        public async Task<ReceiveItemsNewReleaseRecepit> GetReceiveItemsNewReleaseRecepitById(int receiveItemsNewReleaseRecepitId)
        {
            return await _context.ReceiveItemsNewReleaseRecepit.FirstOrDefaultAsync(p => p.Id == receiveItemsNewReleaseRecepitId)??new ReceiveItemsNewReleaseRecepit();
        }

        public async Task<ReceiveItemsNewReleaseRecepit> UpdateReceiveItemsNewReleaseRecepit(ReceiveItemsNewReleaseRecepit toUpdate )
        {
            _context.ReceiveItemsNewReleaseRecepit.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
