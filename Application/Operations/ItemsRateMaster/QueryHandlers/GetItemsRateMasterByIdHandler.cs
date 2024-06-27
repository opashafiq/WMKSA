using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.ItemsRateMaster.Queries;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMaster.QueryHandlers
{
    public class GetItemsRateMasterByIdHandler : IRequestHandler<GetItemsRateMasterById, ItemsRateMasterDto>
    {
        private readonly IItemsRateMasterRepository _itemsRateMasterRepository;
        private readonly ICustomerMasterRepository _customerMasterRepository;

        public GetItemsRateMasterByIdHandler(IItemsRateMasterRepository itemsRateMasterRepository, ICustomerMasterRepository customerMasterRepository)
        {
            _itemsRateMasterRepository = itemsRateMasterRepository;
            _customerMasterRepository = customerMasterRepository;
        }

        public async Task<ItemsRateMasterDto> Handle(GetItemsRateMasterById request, CancellationToken cancellationToken)
        {
            var itemsRateMaster = await _itemsRateMasterRepository.GetItemsRateMasterById(request.Id);

            ICollection<Domain.Entities.ItemsRateMaster> listItemsRateMaster = 
                new HashSet<Domain.Entities.ItemsRateMaster>();

            listItemsRateMaster.Add(itemsRateMaster);
            var customerMaster = await _customerMasterRepository.GetAll();

            var finalitemsRateMasterDto =
                    (from irm in listItemsRateMaster
                     join cm in customerMaster
                     on irm.CustomerMasterId equals cm.Id
                     select new Common.Dtos.ItemsRateMasterDto
                     {
                         ItemsRateMasterId = itemsRateMaster.Id,
                         RateCode = itemsRateMaster.RateCode,
                         CustomerMasterId = itemsRateMaster.CustomerMasterId,
                         CustomerMasterCustCode = cm.CustCode,
                         CustomerMasterCustName=cm.CustName,
                         EntryBy = itemsRateMaster.EntryBy,
                         EntryDate = itemsRateMaster.EntryDate

                     }).ToList().FirstOrDefault();

            return finalitemsRateMasterDto;
        }
    }
}
