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
    
    public record GetUSPGateInReport : IRequest<USPGateInReportDto>
    {
        public long _receiveItemsNewId;

        public GetUSPGateInReport(long receiveItemsNewId)
        {
            _receiveItemsNewId = receiveItemsNewId;

        }

    };
}
