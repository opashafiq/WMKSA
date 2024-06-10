using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.PackageMaster.Queries
{
    public record GetPackageMasterById : IRequest<Domain.Entities.PackageMaster>
    {
        public int Id { get; set; }
        public GetPackageMasterById(int _id)
        {
            Id = _id;
        }

    };
}
