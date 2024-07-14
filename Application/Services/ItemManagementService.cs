using Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ItemManagementService : IItemManagementService
    {
        private readonly IReceiveItemsNewRepository _receiveItemsNewRepository;

        public ItemManagementService(IReceiveItemsNewRepository receiveItemsNewRepository)
        {
            _receiveItemsNewRepository = receiveItemsNewRepository;
        }

        public async Task CheckReleaseQuantityAsync(int quantity , long receiveItemId)
        {
            // Check whether release qty > Qty
            var receiveItemsNew = await _receiveItemsNewRepository.GetReceiveItemsNewById((int)(receiveItemId));
            if (receiveItemsNew.RelasedQty + quantity > receiveItemsNew.Qty)
            {
                throw new Exception("Released Qty Can not be greater than Received Qty");
            }
        }

        public async Task UpdateReleaseQuantityAsync(int quantity, long receiveItemId)
        {
            // Update Released Qty in ReceiveItemsNew table
            var receiveItemsNew = await _receiveItemsNewRepository.GetReceiveItemsNewById((int)(receiveItemId));
            receiveItemsNew.RelasedQty = receiveItemsNew.RelasedQty + quantity;
            var resultReceiveItemsNew = await _receiveItemsNewRepository.UpdateReceiveItemsNew(receiveItemsNew);
        }

    }
}
