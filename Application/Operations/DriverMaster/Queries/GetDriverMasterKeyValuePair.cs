using Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.DriverMaster.Queries
{
    public record GetDriverMasterKeyValuePair : IRequest<ICollection<DriverMasterDto>>
    {
        public int Id { get; set; }
        public GetDriverMasterKeyValuePair()
        {
        }

    };
}
