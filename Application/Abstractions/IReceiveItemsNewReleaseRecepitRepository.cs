using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface IReceiveItemsNewReleaseRecepitRepository
    {
        Task<ICollection<Domain.Entities.ReceiveItemsNewReleaseRecepit>> GetAll();

        Task<Domain.Entities.ReceiveItemsNewReleaseRecepit> GetReceiveItemsNewReleaseRecepitById(int receiveItemsNewReleaseRecepitId);

        Task<Domain.Entities.ReceiveItemsNewReleaseRecepit> AddReceiveItemsNewReleaseRecepit(Domain.Entities.ReceiveItemsNewReleaseRecepit toCreate);

        Task<Domain.Entities.ReceiveItemsNewReleaseRecepit> UpdateReceiveItemsNewReleaseRecepit(Domain.Entities.ReceiveItemsNewReleaseRecepit toUpdate);

        Task<Domain.Entities.ReceiveItemsNewReleaseRecepit> DeleteReceiveItemsNewReleaseRecepit(int receiveItemsNewReleaseRecepitId);
    }
}
