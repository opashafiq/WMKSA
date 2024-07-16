using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface IReceiveItemsNewReleaseInvoiceRepository
    {
        Task<ICollection<Domain.Entities.ReceiveItemsNewReleaseInvoice>> GetAll();

        Task<Domain.Entities.ReceiveItemsNewReleaseInvoice> GetReceiveItemsNewReleaseInvoiceById(int receiveItemsNewReleaseInvoice);

        Task<Domain.Entities.ReceiveItemsNewReleaseInvoice> AddReceiveItemsNewReleaseInvoice(Domain.Entities.ReceiveItemsNewReleaseInvoice toCreate);

        Task<Domain.Entities.ReceiveItemsNewReleaseInvoice> UpdateReceiveItemsNewReleaseInvoice(Domain.Entities.ReceiveItemsNewReleaseInvoice toUpdate);

        Task<Domain.Entities.ReceiveItemsNewReleaseInvoice> DeleteReceiveItemsNewReleaseInvoice(int receiveItemsNewReleaseInvoice);
    }
}
