using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.DriverMaster.Commands;
using Application.Operations.DriverMaster.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.DriverMaster.QueryHandlers
{
    public class GetDriverMasterByIdHandler : IRequestHandler<GetDriverMasterById, DriverMasterDto>
    {
        private readonly IDriverMasterRepository _driverMasterRepository;
        private readonly ITransporterMasterRepository _transporterMasterRepository;
        public GetDriverMasterByIdHandler(
            IDriverMasterRepository driverMasterRepository,
            ITransporterMasterRepository transporterMasterRepository)
        {
            _driverMasterRepository = driverMasterRepository;
            _transporterMasterRepository = transporterMasterRepository;
        }

        public async Task<DriverMasterDto> Handle(GetDriverMasterById request, CancellationToken cancellationToken)
        {
            var driverMaster = await _driverMasterRepository.GetDriverMasterById(request.Id);
            var driverMasterSingleDto = new DriverMasterDto
            {
                Id = request.Id,
                DriverCode = driverMaster.DriverCode,
                DriverName = driverMaster.DriverName,
                Company = driverMaster.Company,
                DrivingLiscencNo = driverMaster.DrivingLiscencNo,
                ExpiryDate = driverMaster.ExpiryDate,
                IdCopy = driverMaster.IdCopy,
                MobileNo = driverMaster.MobileNo,
                TelNo = driverMaster.TelNo,
                EntryBy = driverMaster.EntryBy,
                EntryDate = driverMaster.EntryDate,
                DriverNo = driverMaster.DriverNo,
                TransporterMasterId = driverMaster.TransporterMasterId,
                ImageBase64 = driverMaster.Image == null? null: Convert.ToBase64String(driverMaster.Image)
            };

            ICollection<DriverMasterDto> listDriverMasterDto = new HashSet<DriverMasterDto>();
            listDriverMasterDto.Add(driverMasterSingleDto);
            var transporterMaster = await _transporterMasterRepository.GetAll();

            var finalDriverMasterDto =
                    (from dm in listDriverMasterDto
                     join trnsptm in transporterMaster
                     on dm.TransporterMasterId equals trnsptm.Id
                     select new DriverMasterDto
                     {
                         Id = dm.Id,
                         DriverCode=dm.DriverCode,
                         DriverName=dm.DriverName,
                         Company=dm.Company,
                         DrivingLiscencNo=dm.DrivingLiscencNo,
                         ExpiryDate=dm.ExpiryDate,
                         IdCopy=dm.IdCopy,
                         MobileNo=dm.MobileNo,
                         TelNo=dm.TelNo,
                         EntryBy=dm.EntryBy,
                         EntryDate=dm.EntryDate,
                         DriverNo=dm.DriverNo,
                         TransporterMasterId=dm.TransporterMasterId,
                         TransporterMasterTransCode=trnsptm.TransCode,
                         TransporterMasterTransName=trnsptm.TransName,
                         ImageBase64=dm.ImageBase64
                         
                     }).ToList().FirstOrDefault();

            return finalDriverMasterDto;
        }
    }
}
