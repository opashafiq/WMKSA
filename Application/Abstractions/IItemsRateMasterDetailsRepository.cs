using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface IItemsRateMasterDetailsRepository
    {
        Task<ICollection<Domain.Entities.ItemsRateMasterDetail>> GetAll();

        Task<Domain.Entities.ItemsRateMasterDetail> GetItemsRateMasterDetailsById(int itemsRateMasterDetailsId);

        Task<Domain.Entities.ItemsRateMasterDetail> AddItemsRateMasterDetails(Domain.Entities.ItemsRateMasterDetail toCreate);

        Task<Domain.Entities.ItemsRateMasterDetail> UpdateItemsRateMasterDetails(Domain.Entities.ItemsRateMasterDetail toUpdate);

        Task<Domain.Entities.ItemsRateMasterDetail> DeleteItemsRateMasterDetails(int itemsRateMasterDetailsId);
    }
}
