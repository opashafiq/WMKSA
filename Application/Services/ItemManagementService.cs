using Application.Abstractions;
using Domain.Entities;
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
        private readonly IJobOrderRepository _jobOrderRepository;

        public ItemManagementService(IReceiveItemsNewRepository receiveItemsNewRepository, IJobOrderRepository jobOrderRepository)
        {
            _receiveItemsNewRepository = receiveItemsNewRepository;
            _jobOrderRepository = jobOrderRepository;
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

            var jobOrder = await _jobOrderRepository.GetJobOrderById((long)(receiveItemsNew.JobOrderId));
            if (receiveItemsNew.RelasedQty == 0)
            {
                jobOrder.JobStatus = 1;
                _jobOrderRepository.UpdateJobOrder(jobOrder);
            }
            else if (receiveItemsNew.Qty == receiveItemsNew.RelasedQty)
            {
                jobOrder.JobStatus = 3;
                _jobOrderRepository.UpdateJobOrder(jobOrder);
            }
            else
            {
                jobOrder.JobStatus = 2;
                _jobOrderRepository.UpdateJobOrder(jobOrder);
            }

        }

    }
}
