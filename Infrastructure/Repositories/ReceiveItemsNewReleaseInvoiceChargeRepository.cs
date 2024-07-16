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
    public class ReceiveItemsNewReleaseInvoiceChargeRepository : IReceiveItemsNewReleaseInvoiceChargeRepository
    {
        private readonly ApplicationDBContext _context;

        public ReceiveItemsNewReleaseInvoiceChargeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ReceiveItemsNewReleaseInvoiceCharge> AddReceiveItemsNewReleaseInvoiceCharge(ReceiveItemsNewReleaseInvoiceCharge toCreate)
        {
            _context.ReceiveItemsNewReleaseInvoiceCharge.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<ReceiveItemsNewReleaseInvoiceCharge> DeleteReceiveItemsNewReleaseInvoiceCharge(int personId)
        {
            var receiveItemsNewReleaseInvoiceCharge = _context.ReceiveItemsNewReleaseInvoiceCharge
                .FirstOrDefault(p => p.Id == personId);

            if (receiveItemsNewReleaseInvoiceCharge is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.ReceiveItemsNewReleaseInvoiceCharge.Remove(receiveItemsNewReleaseInvoiceCharge);

            await _context.SaveChangesAsync();
            return receiveItemsNewReleaseInvoiceCharge;

        }



        public async Task<ICollection<ReceiveItemsNewReleaseInvoiceCharge>> GetAll()
        {
            return await _context.ReceiveItemsNewReleaseInvoiceCharge.ToListAsync();
        }

        public async Task<ReceiveItemsNewReleaseInvoiceCharge> GetReceiveItemsNewReleaseInvoiceChargeById(int receiveItemsNewReleaseInvoiceChargeId)
        {
            return await _context.ReceiveItemsNewReleaseInvoiceCharge.FirstOrDefaultAsync(p => p.Id == receiveItemsNewReleaseInvoiceChargeId)??new ReceiveItemsNewReleaseInvoiceCharge();
        }

        public async Task<ReceiveItemsNewReleaseInvoiceCharge> UpdateReceiveItemsNewReleaseInvoiceCharge(ReceiveItemsNewReleaseInvoiceCharge toUpdate )
        {
            _context.ReceiveItemsNewReleaseInvoiceCharge.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
