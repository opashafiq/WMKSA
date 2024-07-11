using Application.Abstractions;
using Application.Common.Dtos;
using Application.Operations.ReceiveItemsNew.Commands;
using Application.Operations.ReceiveItemsNew.Queries;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNew.QueryHandlers
{
    public class GetReceiveItemsNewByIdHandler : IRequestHandler<GetReceiveItemsNewById, ReceiveItemsNewDto>
    {
        private readonly IReceiveItemsNewRepository _receiveItemsNewRepository;
        private readonly IRecItemMasterRepository _recItemMasterRepository;
        private readonly IUnitMasterRepository _unitMasterRepository;
        private readonly ICustomerMasterRepository _customerMasterRepository;
        private readonly ISubCustomerMasterRepository _subCustomerMasterRepository;
        private readonly IJobOrderRepository _jobOrderRepository;
        private readonly ITruckMasterRepository _truckMasterRepository;
        private readonly IDriverMasterRepository _driverMasterRepository;
        private readonly ITransporterMasterRepository _transporterMasterRepository;
        public GetReceiveItemsNewByIdHandler(
            IReceiveItemsNewRepository receiveItemsNewRepository,
            IRecItemMasterRepository recItemMasterRepository,
            IUnitMasterRepository unitMasterRepository,
            ICustomerMasterRepository customerMasterRepository,
            ISubCustomerMasterRepository subCustomerMasterRepository,
            IJobOrderRepository jobOrderRepository,
            ITruckMasterRepository truckMasterRepository,
            IDriverMasterRepository driverMasterRepository,
            ITransporterMasterRepository transporterMasterRepository
            )
        {
            _receiveItemsNewRepository = receiveItemsNewRepository;
            _recItemMasterRepository = recItemMasterRepository;
            _unitMasterRepository = unitMasterRepository;
            _customerMasterRepository = customerMasterRepository;
            _subCustomerMasterRepository = subCustomerMasterRepository;
            _driverMasterRepository = driverMasterRepository;
            _jobOrderRepository = jobOrderRepository;
            _transporterMasterRepository = transporterMasterRepository;
            _truckMasterRepository = truckMasterRepository;
        }

        public async Task<ReceiveItemsNewDto> Handle(GetReceiveItemsNewById request, CancellationToken cancellationToken)
        {
            var receiveItemsNew = await _receiveItemsNewRepository.GetReceiveItemsNewById(request.Id);
            ICollection<Domain.Entities.ReceiveItemsNew> listReceiveItemsNew = new HashSet<Domain.Entities.ReceiveItemsNew>();
            listReceiveItemsNew.Add(receiveItemsNew);
            

            var finalReceiveItemsNewDto =
                    (from ri in listReceiveItemsNew
                     join rim in await _recItemMasterRepository.GetAll()
                     on ri.RecItemMasterId equals rim.Id
                     join um in await _unitMasterRepository.GetAll()
                     on ri.UnitMasterId equals um.Id
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


                     select new ReceiveItemsNewDto
                     {
                         Id = ri.Id,
                         Eirno = ri.Eirno,
                         ReceiveDate = ri.ReceiveDate,
                         RecItemMasterId = ri.RecItemMasterId,
                         RecItemMasterItemCode = rim.ItemCode,
                         RecItemMasterItemDesc = rim.ItemDesc,
                         ItemsDesc = ri.ItemsDesc,
                         UnitMasterId = ri.UnitMasterId,
                         UnitMasterMainUnit = um.MainUnit,
                         UnitMasterUnitCode = um.UnitCode,
                         Qty = ri.Qty,
                         RelasedQty=ri.RelasedQty,
                         CustomerMasterId = ri.CustomerMasterId,
                         CustomerMasterCustCode = cm.CustCode,
                         CustomerMasterCustName = cm.CustName,
                         SubCustomerMasterId = ri.SubCustomerMasterId,
                         SubCustomerMasterCustCode = scm.CustCode,
                         SubCustomerMasterCustName = scm.CustName,
                         Condition = ri.Condition,
                         InvoiceNo = ri.InvoiceNo,
                         PurchaseInvoiceNo = ri.PurchaseInvoiceNo,
                         InvoiceDate = ri.InvoiceDate,
                         Erpno = ri.Erpno,
                         JobOrderId = ri.JobOrderId,
                         JobOrderJobFIleNo = jo.JobFileNo,
                         JobOrderJobStatus = jo.JobStatus,
                         Pono = ri.Pono,
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
                         RecTime = ri.RecTime,
                         EntryBy = ri.EntryBy,
                         EntryDate = ri.EntryDate

                     }).ToList().FirstOrDefault();

            return finalReceiveItemsNewDto;
        }
    }
}
