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
    public class ItemsRateMasterDetailsRepository : IItemsRateMasterDetailsRepository
    {
        private readonly ApplicationDBContext _context;

        public ItemsRateMasterDetailsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ItemsRateMasterDetail> AddItemsRateMasterDetails(ItemsRateMasterDetail toCreate)
        {
            _context.ItemsRateMasterDetail.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<ItemsRateMasterDetail> DeleteItemsRateMasterDetails(int personId)
        {
            var itemsRateMasterDetails = _context.ItemsRateMasterDetail
                .FirstOrDefault(p => p.Id == personId);

            if (itemsRateMasterDetails is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.ItemsRateMasterDetail.Remove(itemsRateMasterDetails);

            await _context.SaveChangesAsync();
            return itemsRateMasterDetails;

        }



        public async Task<ICollection<ItemsRateMasterDetail>> GetAll()
        {
            return await _context.ItemsRateMasterDetail.ToListAsync();
        }

        public async Task<ItemsRateMasterDetail> GetItemsRateMasterDetailsById(int itemsRateMasterDetailsId)
        {
            return await _context.ItemsRateMasterDetail.FirstOrDefaultAsync(p => p.Id == itemsRateMasterDetailsId);
        }

        public async Task<ItemsRateMasterDetail> UpdateItemsRateMasterDetails(ItemsRateMasterDetail toUpdate )
        {
            _context.ItemsRateMasterDetail.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
