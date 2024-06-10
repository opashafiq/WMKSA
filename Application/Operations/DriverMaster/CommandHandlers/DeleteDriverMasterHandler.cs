using Application.Abstractions;
using Application.Operations.DriverMaster.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.DriverMaster.CommandHandlers
{
    public class DeleteDriverMasterHandler : IRequestHandler<DeleteDriverMaster, Domain.Entities.DriverMaster>
    {
        private readonly IDriverMasterRepository _driverMasterRepository;


        public DeleteDriverMasterHandler(IDriverMasterRepository driverMasterRepository)
        {
            _driverMasterRepository = driverMasterRepository;
        }

        async Task<Domain.Entities.DriverMaster> IRequestHandler<DeleteDriverMaster, Domain.Entities.DriverMaster>.Handle(DeleteDriverMaster request, CancellationToken cancellationToken)
        {
            return await _driverMasterRepository.DeleteDriverMaster(request.Id);

        }
    }
}
