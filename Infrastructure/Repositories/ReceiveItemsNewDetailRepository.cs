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
    public class ReceiveItemsNewDetailRepository : IReceiveItemsNewDetailRepository
    {
        private readonly ApplicationDBContext _context;

        public ReceiveItemsNewDetailRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ReceiveItemsNewDetail> AddReceiveItemsNewDetail(ReceiveItemsNewDetail toCreate)
        {
            _context.ReceiveItemsNewDetails.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<ReceiveItemsNewDetail> DeleteReceiveItemsNewDetail(int personId)
        {
            var receiveItemsNewDetail = _context.ReceiveItemsNewDetails
                .FirstOrDefault(p => p.Id == personId);

            if (receiveItemsNewDetail is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.ReceiveItemsNewDetails.Remove(receiveItemsNewDetail);

            await _context.SaveChangesAsync();
            return receiveItemsNewDetail;

        }



        public async Task<ICollection<ReceiveItemsNewDetail>> GetAll()
        {
            return await _context.ReceiveItemsNewDetails.ToListAsync();
        }
                
        public async Task<ICollection<ReceiveItemsNewDetail>> GetAllbyMasterId(long receiveItemsNewId)
        {
            return await _context.ReceiveItemsNewDetails.Where(p=> p.ReceiveItemsNewId==receiveItemsNewId).ToListAsync();
        }

        public async Task<ReceiveItemsNewDetail> GetReceiveItemsNewDetailById(int receiveItemsNewDetailId)
        {
            return await _context.ReceiveItemsNewDetails.FirstOrDefaultAsync(p => p.Id == receiveItemsNewDetailId)??new ReceiveItemsNewDetail();
        }

        public async Task<ReceiveItemsNewDetail> UpdateReceiveItemsNewDetail(ReceiveItemsNewDetail toUpdate)
        {
            _context.ReceiveItemsNewDetails.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
