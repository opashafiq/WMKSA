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
    public class ReceiveItemsNewReleaseInvoiceRepository : IReceiveItemsNewReleaseInvoiceRepository
    {
        private readonly ApplicationDBContext _context;

        public ReceiveItemsNewReleaseInvoiceRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ReceiveItemsNewReleaseInvoice> AddReceiveItemsNewReleaseInvoice(ReceiveItemsNewReleaseInvoice toCreate)
        {
            _context.ReceiveItemsNewReleaseInvoice.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<ReceiveItemsNewReleaseInvoice> DeleteReceiveItemsNewReleaseInvoice(int receiveItemsNewReleaseInvoiceId)
        {
            var receiveItemsNewReleaseInvoice = _context.ReceiveItemsNewReleaseInvoice
                .FirstOrDefault(p => p.Id == receiveItemsNewReleaseInvoiceId);

            if (receiveItemsNewReleaseInvoice is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.ReceiveItemsNewReleaseInvoice.Remove(receiveItemsNewReleaseInvoice);

            await _context.SaveChangesAsync();
            return receiveItemsNewReleaseInvoice;

        }



        public async Task<ICollection<ReceiveItemsNewReleaseInvoice>> GetAll()
        {
            return await _context.ReceiveItemsNewReleaseInvoice.ToListAsync();
        }

        public async Task<ReceiveItemsNewReleaseInvoice> GetReceiveItemsNewReleaseInvoiceById(int branchMasterId)
        {
            return await _context.ReceiveItemsNewReleaseInvoice.FirstOrDefaultAsync(p => p.Id == branchMasterId)??new ReceiveItemsNewReleaseInvoice();
        }

        public async Task<ReceiveItemsNewReleaseInvoice> UpdateReceiveItemsNewReleaseInvoice(ReceiveItemsNewReleaseInvoice toUpdate )
        {
            _context.ReceiveItemsNewReleaseInvoice.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
