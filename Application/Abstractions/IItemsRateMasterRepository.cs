using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface IItemsRateMasterRepository
    {
        Task<ICollection<Domain.Entities.ItemsRateMaster>> GetAll();

        Task<Domain.Entities.ItemsRateMaster> GetItemsRateMasterById(int itemsRateMasterId);

        Task<Domain.Entities.ItemsRateMaster> AddItemsRateMaster(Domain.Entities.ItemsRateMaster toCreate);

        Task<Domain.Entities.ItemsRateMaster> UpdateItemsRateMaster(Domain.Entities.ItemsRateMaster toUpdate);

        Task<Domain.Entities.ItemsRateMaster> DeleteItemsRateMaster(int itemsRateMasterId);
    }
}
