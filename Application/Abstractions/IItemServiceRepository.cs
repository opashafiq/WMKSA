using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Abstractions
{
    public interface IItemServiceRepository
    {
        Task<ICollection<Domain.Entities.ItemService>> GetAll();

        Task<Domain.Entities.ItemService> GetItemServiceById(int itemServiceId);

        Task<Domain.Entities.ItemService> AddItemService(Domain.Entities.ItemService toCreate);

        Task<Domain.Entities.ItemService> UpdateItemService(Domain.Entities.ItemService toUpdate);

        Task<Domain.Entities.ItemService> DeleteItemService(int itemServiceId);
    }
}
