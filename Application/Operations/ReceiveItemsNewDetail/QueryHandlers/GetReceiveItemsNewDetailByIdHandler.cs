using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.ReceiveItemsNewDetail.Commands;
using Application.Operations.ReceiveItemsNewDetail.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewDetail.QueryHandlers
{
    public class GetReceiveItemsNewDetailByIdHandler : IRequestHandler<GetReceiveItemsNewDetailById, ReceiveItemsNewDetailDto>
    {
        private readonly IReceiveItemsNewDetailRepository _receiveItemsNewDetailRepository;
        private readonly IItemsRateMasterDetailsRepository _itemsRateMasterDetailRepository;
        private readonly IItemsRateMasterRepository _itemsRateMasterRepository;
        private readonly IItemServiceRepository _itemServiceRepository;
        private readonly IRecItemMasterRepository _recItemMasterRepository;
        private readonly IUnitMasterRepository _unitMasterRepository; 
        
        public GetReceiveItemsNewDetailByIdHandler(
            IReceiveItemsNewDetailRepository receiveItemsNewDetailRepository,
            IItemsRateMasterDetailsRepository itemsRateMasterDetailRepository,
            IItemsRateMasterRepository itemsRateMasterRepository,
            IItemServiceRepository itemServiceRepository,
            IRecItemMasterRepository recItemMasterRepository,
            IUnitMasterRepository unitMasterRepository)
        {
            _receiveItemsNewDetailRepository = receiveItemsNewDetailRepository;
            _itemServiceRepository = itemServiceRepository;
            _itemsRateMasterDetailRepository = itemsRateMasterDetailRepository;
            _itemsRateMasterRepository = itemsRateMasterRepository;
            _recItemMasterRepository = recItemMasterRepository;
            _unitMasterRepository = unitMasterRepository;
        }

        public async Task<ReceiveItemsNewDetailDto> Handle(GetReceiveItemsNewDetailById request, CancellationToken cancellationToken)
        {
            var receiveItemsNewDetails = await _receiveItemsNewDetailRepository.GetReceiveItemsNewDetailById(request.Id);
            
            ICollection<Domain.Entities.ReceiveItemsNewDetail> listReceiveItemsNewDetails = new HashSet<Domain.Entities.ReceiveItemsNewDetail>();
            listReceiveItemsNewDetails.Add(receiveItemsNewDetails);


            var finalReceiveItemsNewDetails =
                    (from ri in await _receiveItemsNewDetailRepository.GetAll()
                     join irmd in await _itemsRateMasterDetailRepository.GetAll()
                     on ri.ItemsRateMasterDetailId equals irmd.Id
                     join its in await _itemServiceRepository.GetAll()
                     on irmd.ItemServiceId equals its.Id
                     join irm in await _itemsRateMasterRepository.GetAll()
                     on irmd.ItemsRateMasterId equals irm.Id
                     join rim in await _recItemMasterRepository.GetAll()
                     on irmd.RecItemMasterId equals rim.Id
                     join um in await _unitMasterRepository.GetAll()
                     on irmd.UnitMasterId equals um.Id
                     select new ReceiveItemsNewDetailDto
                     {
                         Id = ri.Id,
                         ItemsRateMasterDetailId = ri.ItemsRateMasterDetailId,
                         ItemServiceId = irmd.ItemServiceId,
                         ItemServiceItemsService = its.ItemsService,
                         RecItemMasterId = irmd.RecItemMasterId,
                         RecItemMasterItemCode = rim.ItemCode,
                         RecItemMasterItemDesc = rim.ItemDesc,
                         UnitMasterId = irmd.UnitMasterId,
                         UnitMasterMaintUnit = um.MainUnit,
                         UnitMasterUnitCode = um.MainUnit,
                         Freedays = ri.Freedays,
                         Charges = ri.Charges,
                         VatInc = ri.VatInc,
                         VatAmo = ri.VatAmo,
                         VatP = ri.VatP,
                         Trate = ri.Trate

                     }).ToList().FirstOrDefault();

            return finalReceiveItemsNewDetails;
        }
    }
}
