using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IAccountsRepository
    {
        Task<ICollection<Domain.Entities.USPGateInAccounts>> GetUSPGateInAccountsAsync(
            int? customerId,
            int? subCustomerId,
            DateTime? dateStart,
            DateTime? dateTo
        );

        Task<ICollection<Domain.Entities.USPGateInCharges>> GetUSPGateInChargesAsync(
            string receiveItemsNewIdParameter
        );        
        

        //Task<Domain.Entities.USPGateInReport> GetUSPGateInReport(long? receiveItemsNewId);

    }
}
