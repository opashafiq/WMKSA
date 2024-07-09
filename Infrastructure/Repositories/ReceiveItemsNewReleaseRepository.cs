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

        // Get Received Items By parameters (Gate In)
        public async Task<ICollection<ReceiveItemsNewReleaseGateOut>> GetGateOutDataAsync(
            int? customerId,
            int? subCustomerId,
            DateTime? dateStart,
            DateTime? dateTo,
            int? status,
            int? itemId,
            string receiptNo,
            string poNumber,
            string truckNo,
            string invoiceNo
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
            var truckNoParam = new SqlParameter("@TruckNo", truckNo ?? (object)DBNull.Value);
            var invoiceNoParam = new SqlParameter("@InvoiceNo", invoiceNo ?? (object)DBNull.Value);

            return await _context.ReceiveItemsNewReleaseGateOut.FromSqlRaw("EXEC [dbo].[USP_GateOut] @CustomerId, @SubCustomerId, @DateStart, @DateTo, @Status, @ItemId, @ReceiptNo, @PoNumber,@TruckNo,@InvoiceNo",
                                                  customerIdParam, subCustomerIdParam, dateStartParam, dateToParam, statusParam, itemIdParam, receiptNoParam, poNumberParam,truckNoParam,invoiceNoParam)
                                      .ToListAsync();
        }
    }
}
