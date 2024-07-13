using Application.Common.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.Report.Queries
{
    
    public record GetAllUSPGateOutItem : IRequest<ICollection<USPGateOutItemDto>>
    {
        public int Id { get; set; }
        public int? _customerId;
        public int? _subCustomerId;
        public DateTime? _dateStart;
        public DateTime? _dateTo;
        public int? _status;
        public int? _itemId;
        public string? _receiptNo;
        public string? _poNumber;
        public string? _truckNo;
        public string? _invoiceNo;
        public GetAllUSPGateOutItem(int? customerId, int? subCustomerId,
            DateTime? dateStart, DateTime? dateTo, int? status, int? itemId,
            string? receiptNo, string? poNumber,string? truckNo,string? invoiceNo)
        {
            _customerId = customerId;
            _subCustomerId = subCustomerId; 
            _dateStart = dateStart;
            _dateTo = dateTo;
            _status = status;
            _itemId = itemId;
            _receiptNo = receiptNo;
            _poNumber = poNumber;
            _truckNo = truckNo;
            _invoiceNo = invoiceNo; 

        }

    };
}
