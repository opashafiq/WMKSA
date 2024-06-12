using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface IReceiveItemsNewRepository
    {
        Task<ICollection<Domain.Entities.ReceiveItemsNew>> GetAll();

        Task<Domain.Entities.ReceiveItemsNew> GetReceiveItemsNewById(int receiveItemsNewId);

        Task<Domain.Entities.ReceiveItemsNew> AddReceiveItemsNew(Domain.Entities.ReceiveItemsNew toCreate);

        Task<Domain.Entities.ReceiveItemsNew> UpdateReceiveItemsNew(Domain.Entities.ReceiveItemsNew toUpdate);

        Task<Domain.Entities.ReceiveItemsNew> DeleteReceiveItemsNew(int receiveItemsNewId);
    }
}
