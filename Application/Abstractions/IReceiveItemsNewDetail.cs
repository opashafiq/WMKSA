using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface IReceiveItemsNewDetailRepository
    {
        Task<ICollection<Domain.Entities.ReceiveItemsNewDetail>> GetAll();
        Task<ICollection<Domain.Entities.ReceiveItemsNewDetail>> GetAllbyMasterId(long receiveItemsNewId);

        Task<Domain.Entities.ReceiveItemsNewDetail> GetReceiveItemsNewDetailById(int receiveItemsNewDetailId);

        Task<Domain.Entities.ReceiveItemsNewDetail> AddReceiveItemsNewDetail(Domain.Entities.ReceiveItemsNewDetail toCreate);

        Task<Domain.Entities.ReceiveItemsNewDetail> UpdateReceiveItemsNewDetail(Domain.Entities.ReceiveItemsNewDetail toUpdate);

        Task<Domain.Entities.ReceiveItemsNewDetail> DeleteReceiveItemsNewDetail(int receiveItemsNewDetailId);
    }
}
