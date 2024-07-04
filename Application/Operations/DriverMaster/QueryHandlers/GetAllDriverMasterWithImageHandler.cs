using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.DriverMaster.Queries;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.DriverMaster.QueryHandlers
{
    public class GetAllDriverMasterWithImageHandler : IRequestHandler<GetAllDriverMasterWithImage, ICollection<DriverMasterDto>>
    {
        private readonly IDriverMasterRepository _driverMasterRepository;
        private readonly ITransporterMasterRepository _transporterMasterRepository;

        public GetAllDriverMasterWithImageHandler(
            IDriverMasterRepository driverMasterRepository, ITransporterMasterRepository transporterMasterRepository)
        {
            _driverMasterRepository = driverMasterRepository;
            _transporterMasterRepository = transporterMasterRepository;
        }

        public async Task<ICollection<DriverMasterDto>> Handle(GetAllDriverMasterWithImage request, CancellationToken cancellationToken)
        {
            var driverMasterDto =
                              (from dm in await _driverMasterRepository.GetAll()
                               join trnsptm in await _transporterMasterRepository.GetAll()
                               on dm.TransporterMasterId equals trnsptm.Id
                               select new DriverMasterDto
                               {
                                   Id = dm.Id,
                                   DriverCode = dm.DriverCode,
                                   DriverName = dm.DriverName,
                                   Company = dm.Company,
                                   DrivingLiscencNo = dm.DrivingLiscencNo,
                                   ExpiryDate = dm.ExpiryDate,
                                   IdCopy = dm.IdCopy,
                                   MobileNo = dm.MobileNo,
                                   TelNo = dm.TelNo,
                                   EntryBy = dm.EntryBy,
                                   EntryDate = dm.EntryDate,
                                   DriverNo = dm.DriverNo,
                                   TransporterMasterId = dm.TransporterMasterId,
                                   TransporterMasterTransCode = trnsptm.TransCode,
                                   TransporterMasterTransName = trnsptm.TransName,
                                   ImageBase64 = dm.ImageBase64 == null ? null : Convert.ToBase64String(dm.ImageBase64)
                               }).ToList();


            return driverMasterDto;
        }
    }
}
