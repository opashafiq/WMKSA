using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface IReceiveItemsNewReleaseInvoiceChargeRepository
    {
        Task<ICollection<Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge>> GetAll();

        Task<Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge> GetReceiveItemsNewReleaseInvoiceChargeById(int receiveItemsNewReleaseInvoiceChargeId);

        Task<Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge> AddReceiveItemsNewReleaseInvoiceCharge(Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge toCreate);

        Task<Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge> UpdateReceiveItemsNewReleaseInvoiceCharge(Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge toUpdate);

        Task<Domain.Entities.ReceiveItemsNewReleaseInvoiceCharge> DeleteReceiveItemsNewReleaseInvoiceCharge(int receiveItemsNewReleaseInvoiceChargeId);
    }
}
