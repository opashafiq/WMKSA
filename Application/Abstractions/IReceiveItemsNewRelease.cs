using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface IReceiveItemsNewReleaseRepository
    {
        Task<ICollection<Domain.Entities.ReceiveItemsNewRelease>> GetAll();

        Task<Domain.Entities.ReceiveItemsNewRelease> GetReceiveItemsNewReleaseById(int receiveItemsNewReleaseId);

        Task<Domain.Entities.ReceiveItemsNewRelease> AddReceiveItemsNewRelease(Domain.Entities.ReceiveItemsNewRelease toCreate);

        Task<Domain.Entities.ReceiveItemsNewRelease> UpdateReceiveItemsNewRelease(Domain.Entities.ReceiveItemsNewRelease toUpdate);

        Task<Domain.Entities.ReceiveItemsNewRelease> DeleteReceiveItemsNewRelease(int receiveItemsNewReleaseId);
    }
}
