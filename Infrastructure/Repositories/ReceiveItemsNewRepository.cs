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
    public class ReceiveItemsNewRepository : IReceiveItemsNewRepository
    {
        private readonly ApplicationDBContext _context;

        public ReceiveItemsNewRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ReceiveItemsNew> AddReceiveItemsNew(ReceiveItemsNew toCreate)
        {
            _context.ReceiveItemsNew.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<ReceiveItemsNew> DeleteReceiveItemsNew(int personId)
        {
            var receiveItemsNew = _context.ReceiveItemsNew
                .FirstOrDefault(p => p.Id == personId);

            if (receiveItemsNew is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.ReceiveItemsNew.Remove(receiveItemsNew);

            await _context.SaveChangesAsync();
            return receiveItemsNew;

        }



        public async Task<ICollection<ReceiveItemsNew>> GetAll()
        {
            return await _context.ReceiveItemsNew.ToListAsync();
        }

        public async Task<ReceiveItemsNew> GetReceiveItemsNewById(int receiveItemsNewId)
        {
            return await _context.ReceiveItemsNew.FirstOrDefaultAsync(p => p.Id == receiveItemsNewId);
        }

        public async Task<ReceiveItemsNew> UpdateReceiveItemsNew(ReceiveItemsNew toUpdate )
        {
            _context.ReceiveItemsNew.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
