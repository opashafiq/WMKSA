using Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.TruckMaster.Queries
{
    public record GetTruckMasterByTruckNo : IRequest<TruckMasterDto>
    {
        public string TruckNo { get; set; }
        public GetTruckMasterByTruckNo(string _truckNo)
        {
            TruckNo = _truckNo;
        }

    };
}
