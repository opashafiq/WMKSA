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
    public class ItemServiceRepository : IItemServiceRepository
    {
        private readonly ApplicationDBContext _context;

        public ItemServiceRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ItemService> AddItemService(ItemService toCreate)
        {
            _context.ItemService.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<ItemService> DeleteItemService(int personId)
        {
            var itemService = _context.ItemService
                .FirstOrDefault(p => p.Id == personId);

            if (itemService is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.ItemService.Remove(itemService);

            await _context.SaveChangesAsync();
            return itemService;

        }



        public async Task<ICollection<ItemService>> GetAll()
        {
            return await _context.ItemService.ToListAsync();
        }

        public async Task<ItemService> GetItemServiceById(int itemServiceId)
        {
            return await _context.ItemService.FirstOrDefaultAsync(p => p.Id == itemServiceId);
        }

        public async Task<ItemService> UpdateItemService(ItemService toUpdate )
        {
            _context.ItemService.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
