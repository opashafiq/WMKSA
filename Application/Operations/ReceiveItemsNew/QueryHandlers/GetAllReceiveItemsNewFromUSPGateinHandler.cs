using Application.Abstractions;
using Application.Common.Dtos;
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
    public class GetAllReceiveItemsNewFromUSPGateinHandler : IRequestHandler<GetAllReceiveItemsNewFromUSPGatein, ICollection<ReceiveItemsNewFromUSPGateinDto>>
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

        public GetAllReceiveItemsNewFromUSPGateinHandler(
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

        public async Task<ICollection<ReceiveItemsNewFromUSPGateinDto>> Handle(GetAllReceiveItemsNewFromUSPGatein request, CancellationToken cancellationToken)
        {
            var receiveItemsNewFromUSPGateinDto =
                              (from ri in await _receiveItemsNewRepository.GetGateInDataAsync(
                                  request._customerId,request._subCustomerId,request._dateStart,
                                  request._dateTo,request._status,request._itemId,request._receiptNo,
                                  request._poNumber
                                  )
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


                               select new ReceiveItemsNewFromUSPGateinDto
                               {
                                   Id = ri.Id,
                                   Eirno = ri.Eirno,   
                                   ReceiveDate = ri.ReceiveDate,
                                   RecItemMasterId = ri.RecItemMasterId,
                                   RecItemMasterItemCode=rim.ItemCode,
                                   RecItemMasterItemDesc=rim.ItemDesc,
                                   ItemsDesc = ri.ItemsDesc,
                                   UnitMasterId = ri.UnitMasterId,
                                   UnitMasterMainUnit=um.MainUnit,
                                   UnitMasterUnitCode=um.UnitCode,
                                   Qty=ri.Qty,
                                   CustomerMasterId = ri.CustomerMasterId,
                                   CustomerMasterCustCode=cm.CustCode,
                                   CustomerMasterCustName=cm.CustName,
                                   SubCustomerMasterId=ri.SubCustomerMasterId,
                                   SubCustomerMasterCustCode=scm.CustCode,
                                   SubCustomerMasterCustName=scm.CustName,
                                   Condition=ri.Condition,                                   
                                   InvoiceNo=ri.InvoiceNo,
                                   PurchaseInvoiceNo=ri.PurchaseInvoiceNo,
                                   InvoiceDate = ri.InvoiceDate,
                                   Erpno=ri.Erpno,
                                   JobOrderId=ri.JobOrderId,
                                   JobOrderJobFIleNo=jo.JobFileNo,
                                   JobOrderJobStatus=jo.JobStatus,
                                   Pono=ri.Pono
                               }).ToList();


            return receiveItemsNewFromUSPGateinDto;
        }
    }
}
