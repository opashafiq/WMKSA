using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.DriverMaster.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.DriverMaster.QueryHandlers
{
    public class GetAllDriverMasterHandler : IRequestHandler<GetAllDriverMaster, ICollection<DriverMasterDto>>
    {
        private readonly IDriverMasterRepository _driverMasterRepository;
        private readonly ITransporterMasterRepository _transporterMasterRepository;

        public GetAllDriverMasterHandler(
            IDriverMasterRepository driverMasterRepository, ITransporterMasterRepository transporterMasterRepository)
        {
            _driverMasterRepository = driverMasterRepository;
            _transporterMasterRepository = transporterMasterRepository;
        }

        public async Task<ICollection<DriverMasterDto>> Handle(GetAllDriverMaster request, CancellationToken cancellationToken)
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
                                   ImageBase64 = null

                               }).ToList();


            return driverMasterDto;
        }
    }
}
