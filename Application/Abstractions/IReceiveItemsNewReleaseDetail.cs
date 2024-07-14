using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface IReceiveItemsNewReleaseDetailRepository
    {
        Task<ICollection<Domain.Entities.ReceiveItemsNewReleaseDetail>> GetAll();

        Task<Domain.Entities.ReceiveItemsNewReleaseDetail> GetReceiveItemsNewReleaseDetailById(int receiveItemsNewReleaseDetailId);
        Task<Domain.Entities.ReceiveItemsNewReleaseDetail> GetReceiveItemsNewReleaseDetailByIdAsNoTracking(int receiveItemsNewReleaseDetailId);

        Task<Domain.Entities.ReceiveItemsNewReleaseDetail> AddReceiveItemsNewReleaseDetail(Domain.Entities.ReceiveItemsNewReleaseDetail toCreate);

        Task<Domain.Entities.ReceiveItemsNewReleaseDetail> UpdateReceiveItemsNewReleaseDetail(Domain.Entities.ReceiveItemsNewReleaseDetail toUpdate);

        Task<Domain.Entities.ReceiveItemsNewReleaseDetail> DeleteReceiveItemsNewReleaseDetail(int receiveItemsNewReleaseDetailId);
    }
}
