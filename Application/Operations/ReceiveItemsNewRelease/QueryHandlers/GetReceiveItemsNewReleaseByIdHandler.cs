using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.ReceiveItemsNewRelease.Commands;
using Application.Operations.ReceiveItemsNewRelease.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewRelease.QueryHandlers
{
    public class GetReceiveItemsNewReleaseByIdHandler : IRequestHandler<GetReceiveItemsNewReleaseById, ReceiveItemsNewReleaseDto>
    {
        private readonly IReceiveItemsNewReleaseRepository _receiveItemsNewReleaseRepository;
        private readonly ICustomerMasterRepository _customerMasterRepository;
        private readonly ISubCustomerMasterRepository _subCustomerMasterRepository;
        private readonly IJobOrderRepository _jobOrderRepository;
        private readonly ITruckMasterRepository _truckMasterRepository;
        private readonly IDriverMasterRepository _driverMasterRepository;
        private readonly ITransporterMasterRepository _transporterMasterRepository;

        public GetReceiveItemsNewReleaseByIdHandler(
            IReceiveItemsNewReleaseRepository receiveItemsNewReleaseRepository,
            ICustomerMasterRepository customerMasterRepository,
            ISubCustomerMasterRepository subCustomerMasterRepository,
            IJobOrderRepository jobOrderRepository,
            ITruckMasterRepository truckMasterRepository,
            IDriverMasterRepository driverMasterRepository,
            ITransporterMasterRepository transporterMasterRepository)
        {
            _receiveItemsNewReleaseRepository = receiveItemsNewReleaseRepository;
            _transporterMasterRepository = transporterMasterRepository;
            _customerMasterRepository = customerMasterRepository;
            _subCustomerMasterRepository = subCustomerMasterRepository;
            _jobOrderRepository = jobOrderRepository;
            _driverMasterRepository = driverMasterRepository;
            _truckMasterRepository = truckMasterRepository;
        }

        public async Task<ReceiveItemsNewReleaseDto> Handle(GetReceiveItemsNewReleaseById request, CancellationToken cancellationToken)
        {
            var receiveItemsNewRelease = await _receiveItemsNewReleaseRepository.GetReceiveItemsNewReleaseById(request.Id);
            

            ICollection<Domain.Entities.ReceiveItemsNewRelease> listReceiveItemsNewRelease = new HashSet<Domain.Entities.ReceiveItemsNewRelease>();
            listReceiveItemsNewRelease.Add(receiveItemsNewRelease);
            

            var finalReceiveItemsNewRelease =
                    (from ri in listReceiveItemsNewRelease
                     join cm in await _customerMasterRepository.GetAll()
                     on ri.CustomerMasterId equals cm.Id
                     join scm in await _subCustomerMasterRepository.GetAll()
                     on ri.SubCustomerMasterId equals scm.Id
                     join jo in await _jobOrderRepository.GetAll()
                     on ri.JobOrderId equals jo.Id
                     join tm in await _truckMasterRepository.GetAll()
                     on ri.TruckMasterId equals tm.Id
                     join dm in await _driverMasterRepository.GetAll()
                     on ri.DriverMasterId equals dm.Id
                     join trnsm in await _transporterMasterRepository.GetAll()
                     on ri.TransporterMasterId equals trnsm.Id

                     select new ReceiveItemsNewReleaseDto
                     {
                         Id = ri.Id,
                         Eirno = ri.Eirno,
                         CustomerMasterId = ri.CustomerMasterId,
                         CustomerMasterCustCode = cm.CustCode,
                         CustomerMasterCustName = cm.CustName,
                         SubCustomerMasterId = ri.SubCustomerMasterId,
                         SubCustomerMasterCustCode = scm.CustCode,
                         SubCustomerMasterCustName = scm.CustName,
                         JobOrderId = ri.JobOrderId,
                         JobOrderJobFIleNo = jo.JobFileNo,
                         JobOrderJobStatus = jo.JobStatus,
                         ReleaseDate = ri.ReleaseDate,
                         Trno = ri.Trno,
                         RelReceiptNo = ri.RelReceiptNo,
                         TruckMasterId = ri.TruckMasterId,
                         TruckMasterTruckNo = tm.TruckNo,
                         DriverMasterId = ri.DriverMasterId,
                         DriverMasterDriverCode = dm.DriverCode,
                         DriverMasterDriverName = dm.DriverName,
                         DriverMasterCompany = dm.Company,
                         DriverMasterDrivingLiscencNo = dm.DrivingLiscencNo,
                         DriverMasterIDCopy = dm.IdCopy,
                         DriverMasterMobileNo = dm.MobileNo,
                         TransporterMasterId = ri.TransporterMasterId,
                         TransporterMasterTransCode = trnsm.TransCode,
                         TransporterMasterTransName = trnsm.TransName,
                         EntryBy = ri.EntryBy,
                         EntryDate = ri.EntryDate,

                     }).ToList().FirstOrDefault();

            return finalReceiveItemsNewRelease;
        }
    }
}
