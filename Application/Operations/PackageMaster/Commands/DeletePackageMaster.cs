using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.PackageMaster.Commands
{
    public class DeletePackageMaster : IRequest<Domain.Entities.PackageMaster>
    {
        public int Id { get; set; }

        public DeletePackageMaster(int id)
        {
            Id = id;
        }
    }
}
