﻿using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.ReceiveItemsNewDetail.Queries;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewDetail.QueryHandlers
{
    public class GetAllReceiveItemsNewDetailHandler : IRequestHandler<GetAllReceiveItemsNewDetail, ICollection<ReceiveItemsNewDetailDto>>
    {
        private readonly IReceiveItemsNewRepository _receiveItemsNewRepository;
        private readonly IReceiveItemsNewDetailRepository _receiveItemsNewDetailRepository;
        private readonly IItemsRateMasterDetailsRepository _itemsRateMasterDetailRepository;
        private readonly IItemsRateMasterRepository _itemsRateMasterRepository;
        private readonly IItemServiceRepository _itemServiceRepository;
        private readonly IRecItemMasterRepository _recItemMasterRepository;
        private readonly IUnitMasterRepository _unitMasterRepository;

        public GetAllReceiveItemsNewDetailHandler(
            IReceiveItemsNewRepository receiveItemsNewRepository,
            IReceiveItemsNewDetailRepository receiveItemsNewDetailRepository,
            IItemsRateMasterDetailsRepository itemsRateMasterDetailRepository,
            IItemsRateMasterRepository itemsRateMasterRepository,
            IItemServiceRepository itemServiceRepository,
            IRecItemMasterRepository recItemMasterRepository,
            IUnitMasterRepository unitMasterRepository)
        {
            _receiveItemsNewRepository= receiveItemsNewRepository;
            _receiveItemsNewDetailRepository = receiveItemsNewDetailRepository;
            _itemServiceRepository = itemServiceRepository;
            _itemsRateMasterDetailRepository = itemsRateMasterDetailRepository;   
            _itemsRateMasterRepository = itemsRateMasterRepository;
            _recItemMasterRepository = recItemMasterRepository;
            _unitMasterRepository = unitMasterRepository;
        }

        public async Task<ICollection<ReceiveItemsNewDetailDto>> Handle(GetAllReceiveItemsNewDetail request, CancellationToken cancellationToken)
        {
            var receiveItemsNewDetails =
                              (from ri in await _receiveItemsNewDetailRepository.GetAll()
                               join rin in await _receiveItemsNewRepository.GetAll()
                               on ri.ReceiveItemsNewId equals rin.Id
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
                                   ReceiveItemsNewId=ri.ReceiveItemsNewId,
                                   ItemsRateMasterDetailId = ri.ItemsRateMasterDetailId,    
                                   ItemServiceId=irmd.ItemServiceId,
                                   ItemServiceItemsService=its.ItemsService,
                                   RecItemMasterId=irmd.RecItemMasterId,
                                   RecItemMasterItemCode=rim.ItemCode,
                                   RecItemMasterItemDesc=rim.ItemDesc,
                                   UnitMasterId = irmd.UnitMasterId,
                                   UnitMasterMaintUnit=um.MainUnit,
                                   UnitMasterUnitCode=um.MainUnit,  
                                   Freedays=ri.Freedays,
                                   Charges=ri.Charges,
                                   VatInc=ri.VatInc,
                                   VatAmo=ri.VatAmo,
                                   VatP=ri.VatP,
                                   Trate=ri.Trate

                               }).ToList();


            return receiveItemsNewDetails;
        }
    }
}
