using Application.Abstractions;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDBContext _context;
        public ReportRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<ICollection<USPGateIntItemDetails>> GetUSPGateIntItemDetailsAsync(
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

            return await _context.USPGateIntItemDetails.FromSqlRaw("EXEC [dbo].[USP_GateInItemDetails] @CustomerId, @SubCustomerId, @DateStart, @DateTo, @Status, @ItemId, @ReceiptNo, @PoNumber",
                                                  customerIdParam, subCustomerIdParam, dateStartParam, dateToParam, statusParam, itemIdParam, receiptNoParam, poNumberParam)
                                      .ToListAsync();
        }

        public async Task<ICollection<USPGateOutItem>> GetUSPGateOutItemAsync(
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
            var invoiceNoParam = new SqlParameter("@InvocieNo", invoiceNo ?? (object)DBNull.Value);

            return await _context.USPGateOutItem.FromSqlRaw("EXEC [dbo].[USP_GateOutItem] @CustomerId, @SubCustomerId, @DateStart, @DateTo, @Status, @ItemId, @ReceiptNo, @PoNumber, @TruckNo, @InvocieNo",
                                                  customerIdParam, subCustomerIdParam, dateStartParam, dateToParam, statusParam, itemIdParam, receiptNoParam, poNumberParam, truckNoParam, invoiceNoParam)
                                      .ToListAsync();
        }

        public async Task<USPGateInReport> GetUSPGateInReport(long? receiveItemsNewId)
        {
            var receiveItemsNewIdParam = new SqlParameter("@ReceiveItemsNewId", receiveItemsNewId ?? (object)DBNull.Value);
            var result = await _context.USPGateInReport.FromSqlRaw("EXEC [dbo].[USP_GateInReport] @ReceiveItemsNewId",
                                                  receiveItemsNewIdParam)
                                       .ToListAsync();
            if (result != null & result.Count > 0)
            {
                return result.FirstOrDefault();
            }
            else
            {
                throw new Exception("No Records Found");
            }
        }

        public async Task<USPGateOutReport> GetUSPGateOutReport(long? receiveItemsNewReleaseId)
        {
            var receiveItemsNewReleaseIdParam = new SqlParameter("@ReceiveItemsNewId", receiveItemsNewReleaseId ?? (object)DBNull.Value);
            var result= await _context.USPGateOutReport.FromSqlRaw("EXEC [dbo].[USP_GateOutReport] @ReceiveItemsNewId",
                                                  receiveItemsNewReleaseIdParam)
                                      .ToListAsync();
            if (result != null & result.Count>0)
            {
                return result.FirstOrDefault();
            }
            else
            {
                throw new Exception("No Records Found");
            }
        }


    }
}
