using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.ItemsRateMasterDetails.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMasterDetails.QueryHandlers
{
    public class GetAllItemsRateMasterDetailByCustomParamHandler : IRequestHandler<GetAllItemsRateMasterDetailByCustomParam, ICollection<ItemsRateMasterDetailDto>>
    {
        private readonly IItemsRateMasterDetailsRepository _itemsRateMasterDetailsRepository;
        private readonly IItemServiceRepository _itemServiceRepository;
        private readonly IItemsRateMasterRepository _itemsRateMasterRepository;
        private readonly IUnitMasterRepository _unitMasterRepository;
        private readonly IRecItemMasterRepository _recItemMasterRepository;
        private readonly ICustomerMasterRepository _customerMasterRepository;

        public GetAllItemsRateMasterDetailByCustomParamHandler(
            IItemsRateMasterDetailsRepository itemsRateMasterDetailsRepository,
            IItemServiceRepository itemServiceRepository,
            IItemsRateMasterRepository itemsRateMasterRepository,
            IUnitMasterRepository unitMasterRepository,
            IRecItemMasterRepository recItemMasterRepository,
            ICustomerMasterRepository customerMasterRepository
            )
        {
            _itemsRateMasterDetailsRepository = itemsRateMasterDetailsRepository;
            _itemServiceRepository = itemServiceRepository;
            _unitMasterRepository = unitMasterRepository;
            _itemsRateMasterRepository = itemsRateMasterRepository;
            _recItemMasterRepository = recItemMasterRepository;
            _customerMasterRepository = customerMasterRepository;
        }

        public async Task<ICollection<ItemsRateMasterDetailDto>> Handle(GetAllItemsRateMasterDetailByCustomParam request, CancellationToken cancellationToken)
        {
                        
            var itemsRateMasterDetailDto =
                                (from irmd in await _itemsRateMasterDetailsRepository.GetAll()
                                 join isr in await _itemServiceRepository.GetAll()
                                 on irmd.ItemServiceId equals isr.Id 
                                 join irm in await _itemsRateMasterRepository.GetAll()
                                 on irmd.ItemsRateMasterId equals irm.Id
                                 join um in await _unitMasterRepository.GetAll()
                                 on irmd.UnitMasterId equals um.Id
                                 join rim in await _recItemMasterRepository.GetAll()
                                 on irmd.RecItemMasterId equals rim.Id
                                 join cm in await _customerMasterRepository.GetAll()
                                 on irm.CustomerMasterId equals cm.Id
                                 
                                 where 
                                 cm.Id == request._customerMasterId &
                                 um.Id == request._unitMasterId &
                                 irmd.Id == request._recItemMasterId 

                                 select new ItemsRateMasterDetailDto
                                 {
                                     itemsRateMasterDetailId = irmd.Id,
                                     ItemsRateMasterId = irmd.ItemsRateMasterId,
                                     ItemsRateMasterRateCode=irm.RateCode,
                                     ItemServiceId = irmd.ItemServiceId,
                                     ItemServiceItemsService=isr.ItemsService,
                                     CustomerMasterId=irm.CustomerMasterId,
                                     CustomerMasterCustCode=cm.CustCode,
                                     CustomerMasterCustName=cm.CustName,
                                     FreeDays = irmd.FreeDays,
                                     Charges = irmd.Charges,
                                     VatInc = irmd.VatInc,
                                     VatP = irmd.VatP,
                                     VatAmo = irmd.VatAmo,
                                     Trate=irmd.Trate,
                                     RecItemMasterId=irmd.RecItemMasterId,
                                     RecItemMasterItemCode=rim.ItemCode,
                                     RecItemMasterItemDesc=rim.ItemDesc,
                                     UnitMasterId=irmd.UnitMasterId,
                                     UnitMasterMainUnit=um.MainUnit,
                                     UnitMasterUnitCode=um.UnitCode
   
                                 }).ToList();


            return itemsRateMasterDetailDto;
        }
    }
}
