using Application.Abstractions;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly ApplicationDBContext _context;
        public AccountsRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<ICollection<USPGateInAccounts>> GetUSPGateInAccountsAsync(
            int? customerId,
            int? subCustomerId,
            DateTime? dateStart,
            DateTime? dateTo
        )
        {
            var customerIdParam = new SqlParameter("@CustomerId", customerId ?? (object)DBNull.Value);
            var subCustomerIdParam = new SqlParameter("@SubCustomerId", subCustomerId ?? (object)DBNull.Value);
            var dateStartParam = new SqlParameter("@DateStart", dateStart ?? (object)DBNull.Value);
            var dateToParam = new SqlParameter("@DateTo", dateTo ?? (object)DBNull.Value);

            return await _context.USPGateInAccounts.FromSqlRaw("EXEC [dbo].[USP_GateInAccounts] @CustomerId, @SubCustomerId, @DateStart, @DateTo",
                                                  customerIdParam, subCustomerIdParam, dateStartParam, dateToParam)
                                      .ToListAsync();
        }


        //public async Task<USPGateInReport> GetUSPGateInReport(long? receiveItemsNewId)
        //{
        //    var receiveItemsNewIdParam = new SqlParameter("@ReceiveItemsNewId", receiveItemsNewId ?? (object)DBNull.Value);
        //    var result = await _context.USPGateInReport.FromSqlRaw("EXEC [dbo].[USP_GateInReport] @ReceiveItemsNewId",
        //                                          receiveItemsNewIdParam)
        //                               .ToListAsync();
        //    if (result != null & result.Count > 0)
        //    {
        //        return result.FirstOrDefault();
        //    }
        //    else
        //    {
        //        throw new Exception("No Records Found");
        //    }
        //}

        


    }
}
