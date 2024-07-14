using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IItemManagementService
    {
        Task CheckReleaseQuantityAsync(int quantity,long receiveItemId);
        Task UpdateReleaseQuantityAsync(int quantity,long receiveItemId);
    }
}
