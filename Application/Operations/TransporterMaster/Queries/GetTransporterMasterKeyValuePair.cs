using Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.TransporterMaster.Queries
{
    public record GetTransporterMasterKeyValuePair : IRequest<ICollection<TransporterMasterKeyValueDto>>
    {
        public int Id { get; set; }
        public GetTransporterMasterKeyValuePair()
        {
        }

    };
}
