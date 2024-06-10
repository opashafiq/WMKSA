using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.PackageMaster.Queries
{
    public record GetAllPackageMaster : IRequest<ICollection<Domain.Entities.PackageMaster>>
    {
        public int Id { get; set; }
        public GetAllPackageMaster()
        {
        }

    };
}
