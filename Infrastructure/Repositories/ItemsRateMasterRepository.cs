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
    public class ItemsRateMasterRepository : IItemsRateMasterRepository
    {
        private readonly ApplicationDBContext _context;

        public ItemsRateMasterRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ItemsRateMaster> AddItemsRateMaster(ItemsRateMaster toCreate)
        {
            _context.ItemsRateMaster.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<ItemsRateMaster> DeleteItemsRateMaster(int personId)
        {
            var itemsRateMaster = _context.ItemsRateMaster
                .FirstOrDefault(p => p.Id == personId);

            if (itemsRateMaster is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.ItemsRateMaster.Remove(itemsRateMaster);

            await _context.SaveChangesAsync();
            return itemsRateMaster;

        }



        public async Task<ICollection<ItemsRateMaster>> GetAll()
        {
            return await _context.ItemsRateMaster.ToListAsync();
        }

        public async Task<ItemsRateMaster> GetItemsRateMasterById(int itemsRateMasterId)
        {
            return await _context.ItemsRateMaster.FirstOrDefaultAsync(p => p.Id == itemsRateMasterId)??new ItemsRateMaster();
        }

        public async Task<ItemsRateMaster> UpdateItemsRateMaster(ItemsRateMaster toUpdate )
        {
            _context.ItemsRateMaster.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
