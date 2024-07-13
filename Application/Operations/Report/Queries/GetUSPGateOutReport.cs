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
    
    public record GetUSPGateOutReport : IRequest<USPGateOutReportDto>
    {
        public long _receiveItemsNewReleaseId;

        public GetUSPGateOutReport(long receiveItemsNewReleaseId)
        {
            _receiveItemsNewReleaseId = receiveItemsNewReleaseId;

        }

    };
}
