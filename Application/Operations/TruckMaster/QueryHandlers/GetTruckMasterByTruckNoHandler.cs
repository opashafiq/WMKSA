using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.TruckMaster.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.TruckMaster.QueryHandlers
{
    public class GetTruckMasterByTruckNoHandler : IRequestHandler<GetTruckMasterByTruckNo, TruckMasterDto>
    {
        private readonly ITruckMasterRepository _truckMasterRepository;
        private readonly IDriverMasterRepository _driverMasterRepository;
        private readonly ITransporterMasterRepository _transporterMasterRepository;

        public GetTruckMasterByTruckNoHandler(ITruckMasterRepository truckMasterRepository,
            IDriverMasterRepository driverMasterRepository,
            ITransporterMasterRepository transporterMasterRepository)
        {
            _truckMasterRepository = truckMasterRepository;
            _driverMasterRepository = driverMasterRepository;
            _transporterMasterRepository = transporterMasterRepository;
        }

        public async Task<TruckMasterDto> Handle(GetTruckMasterByTruckNo request, CancellationToken cancellationToken)
        {
            ICollection<Domain.Entities.TruckMaster> truckMaster = new HashSet<Domain.Entities.TruckMaster>();
            truckMaster.Add(await _truckMasterRepository.GetTruckMasterByTruckNo(request.TruckNo));
            var transporterMaster = await _transporterMasterRepository.GetAll();

            var truckMasterDto =
                    (from tm in truckMaster
                     join dm in await _driverMasterRepository.GetAll()
                     on tm.DriverMasterId equals dm.Id
                     join trnsptm in transporterMaster
                     on tm.TransporterMasterId equals trnsptm.Id
                     select new TruckMasterDto
                     {
                         Id = tm.Id,
                         TruckNo = tm.TruckNo,
                         DriverMasterId = tm.DriverMasterId,
                         DriverMasterDriverCode = dm.DriverCode,
                         DriverMasterDriverName = dm.DriverName,
                         TransporterMasterId = tm.TransporterMasterId,
                         TransporterMasterTransCode = trnsptm.TransCode,
                         TransporterMasterTransName = trnsptm.TransName,
                         EntryBy = tm.EntryBy,
                         EntryDate = tm.EntryDate
                     }).ToList().FirstOrDefault();

            return truckMasterDto;
        }
    }
}
