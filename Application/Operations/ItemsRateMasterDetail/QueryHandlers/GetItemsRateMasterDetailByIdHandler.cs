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
    public class GetItemsRateMasterDetailByIdHandler : IRequestHandler<GetItemsRateMasterDetailById, ItemsRateMasterDetailDto>
    {
        private readonly IItemsRateMasterDetailsRepository _itemsRateMasterDetailsRepository;
        private readonly IItemServiceRepository _itemServiceRepository;
        private readonly IItemsRateMasterRepository _itemsRateMasterRepository;
        private readonly IUnitMasterRepository _unitMasterRepository;
        private readonly IRecItemMasterRepository _recItemMasterRepository;
        public GetItemsRateMasterDetailByIdHandler(
            IItemsRateMasterDetailsRepository itemsRateMasterDetailsRepository,
            IItemServiceRepository itemServiceRepository,
            IItemsRateMasterRepository itemsRateMasterRepository,
            IUnitMasterRepository unitMasterRepository,
            IRecItemMasterRepository recItemMasterRepository
            )
        {
            _itemsRateMasterDetailsRepository = itemsRateMasterDetailsRepository;
            _itemServiceRepository = itemServiceRepository;
            _unitMasterRepository = unitMasterRepository;
            _itemsRateMasterRepository = itemsRateMasterRepository;
            _recItemMasterRepository = recItemMasterRepository;
        }

        public async Task<ItemsRateMasterDetailDto> Handle(GetItemsRateMasterDetailById request, CancellationToken cancellationToken)
        {
            ICollection<Domain.Entities.ItemsRateMasterDetail> itemsRateMasterDetail = new HashSet<Domain.Entities.ItemsRateMasterDetail>();
            itemsRateMasterDetail.Add(await _itemsRateMasterDetailsRepository.GetItemsRateMasterDetailsById(request.Id));

            var itemsRateMasterDetailDto =
                                (from irmd in itemsRateMasterDetail
                                 join isr in await _itemServiceRepository.GetAll()
                                 on irmd.ItemServiceId equals isr.Id
                                 join irm in await _itemsRateMasterRepository.GetAll()
                                 on irmd.ItemsRateMasterId equals irm.Id
                                 join um in await _unitMasterRepository.GetAll()
                                 on irmd.UnitMasterId equals um.Id
                                 join rim in await _recItemMasterRepository.GetAll()
                                 on irmd.RecItemMasterId equals rim.Id
                                 select new ItemsRateMasterDetailDto
                                 {
                                     Id = irmd.Id,
                                     ItemsRateMasterId = irmd.ItemsRateMasterId,
                                     ItemsRateMasterRateCode = irm.RateCode,
                                     ItemServiceId = irmd.ItemServiceId,
                                     ItemServiceItemsService = isr.ItemsService,
                                     FreeDays = irmd.FreeDays,
                                     Charges = irmd.Charges,
                                     VatInc = irmd.VatInc,
                                     VatP = irmd.VatP,
                                     VatAmo = irmd.VatAmo,
                                     Trate = irmd.Trate,
                                     RecItemMasterId = irmd.RecItemMasterId,
                                     RecItemMasterItemCode = rim.ItemCode,
                                     RecItemMasterItemDesc = rim.ItemDesc,
                                     UnitMasterId = irmd.UnitMasterId,
                                     UnitMasterMainUnit = um.MainUnit,
                                     UnitMasterUnitCode = um.UnitCode

                                 }).ToList().FirstOrDefault();


            return itemsRateMasterDetailDto;
        }
    }
}
