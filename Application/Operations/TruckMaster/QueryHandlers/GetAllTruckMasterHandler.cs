using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.TruckMaster.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.TruckMaster.QueryHandlers
{
    public class GetAllTruckMasterHandler : IRequestHandler<GetAllTruckMaster, ICollection<TruckMasterDto>>
    {
        private readonly ITruckMasterRepository _truckMasterRepository;
        private readonly IDriverMasterRepository _driverMasterRepository;
        private readonly ITransporterMasterRepository _transporterMasterRepository;
        private readonly IMapper _mapper;
        public GetAllTruckMasterHandler(ITruckMasterRepository truckMasterRepository,
            IDriverMasterRepository driverMasterRepository,
            ITransporterMasterRepository transporterMasterRepository,
            IMapper mapper)
        {
            _truckMasterRepository = truckMasterRepository;
            _driverMasterRepository = driverMasterRepository;
            _transporterMasterRepository = transporterMasterRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<TruckMasterDto>> Handle(GetAllTruckMaster request, CancellationToken cancellationToken)
        {
            var truckMasterDto =
                                (from tm in await _truckMasterRepository.GetAll()
                                 join dm in await _driverMasterRepository.GetAll()
                                 on tm.DriverMasterId equals dm.Id
                                 join trnsptm in await _transporterMasterRepository.GetAll()
                                 on tm.TranspoterMasterId equals trnsptm.Id
                                 select new TruckMasterDto
                                 {
                                     Id = tm.Id,
                                     TruckNo = tm.TruckNo,
                                     DriverMasterId = tm.DriverMasterId,
                                     DriverMasterDriverCode=dm.DriverCode,
                                     DriverMasterDriverName=dm.DriverName,
                                     TranspoterMasterId = tm.TranspoterMasterId,
                                     TranspoterMasterTransCode = trnsptm.TransCode,
                                     TranspoterMasterTransName = trnsptm.TransName,
                                     EntryBy = tm.EntryBy,
                                     EntryDate = tm.EntryDate
                                 }).ToList();


            return truckMasterDto;
        }
    }
}
