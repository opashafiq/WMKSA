using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IReportRepository
    {
        Task<ICollection<Domain.Entities.USPGateIntItemDetails>> GetUSPGateIntItemDetailsAsync(
            int? customerId,
            int? subCustomerId,
            DateTime? dateStart,
            DateTime? dateTo,
            int? status,
            int? itemId,
            string receiptNo,
            string poNumber
        );        
        
        Task<ICollection<Domain.Entities.USPGateOutItem>> GetUSPGateOutItemAsync(
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
        );

        Task<Domain.Entities.USPGateInReport> GetUSPGateInReport(long? receiveItemsNewId);
        Task<Domain.Entities.USPGateOutReport> GetUSPGateOutReport(long? receiveItemsNewReleaseId);

    }
}
