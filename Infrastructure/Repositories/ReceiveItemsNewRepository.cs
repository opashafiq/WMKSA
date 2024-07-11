using Application.Abstractions;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
        
        public async Task<ICollection<ReceiveItemsNew>> GetAllByJobOrderId(long jobOrderId)
        {
            return await _context.ReceiveItemsNew
                .Where(j=>j.JobOrderId==jobOrderId)
                .ToListAsync();
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


        // Get Received Items By parameters (Gate In)
        public async Task<ICollection<ReceiveItemsNewFromUSPGatein>> GetGateInDataAsync(
            int? customerId,
            int? subCustomerId,
            DateTime? dateStart,
            DateTime? dateTo,
            int? status,
            int? itemId,
            string receiptNo,
            string poNumber
        )
        {
            var customerIdParam = new SqlParameter("@CustomerId", customerId ?? (object)DBNull.Value);
            var subCustomerIdParam = new SqlParameter("@SubCustomerId", subCustomerId ?? (object)DBNull.Value);
            var dateStartParam = new SqlParameter("@DateStart", dateStart ?? (object)DBNull.Value);
            var dateToParam = new SqlParameter("@DateTo", dateTo ?? (object)DBNull.Value);
            var statusParam = new SqlParameter("@Status", status ?? (object)DBNull.Value);
            var itemIdParam = new SqlParameter("@ItemId", itemId ?? (object)DBNull.Value);
            var receiptNoParam = new SqlParameter("@ReceiptNo", receiptNo ?? (object)DBNull.Value);
            var poNumberParam = new SqlParameter("@PoNumber", poNumber ?? (object)DBNull.Value);

            return await _context.ReceiveItemsNewFromUSPGatein.FromSqlRaw("EXEC [dbo].[USP_GateIn] @CustomerId, @SubCustomerId, @DateStart, @DateTo, @Status, @ItemId, @ReceiptNo, @PoNumber",
                                                  customerIdParam, subCustomerIdParam, dateStartParam, dateToParam, statusParam, itemIdParam, receiptNoParam, poNumberParam)
                                      .ToListAsync();
        }

    }
}
