using Application.Abstractions;
using Application.Operations.TruckMaster.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.TruckMaster.CommandHandlers
{
    public class DeleteTruckMasterHandler : IRequestHandler<DeleteTruckMaster, Domain.Entities.TruckMaster>
    {
        private readonly ITruckMasterRepository _truckMasterRepository;


        public DeleteTruckMasterHandler(ITruckMasterRepository truckMasterRepository)
        {
            _truckMasterRepository = truckMasterRepository;
        }

        async Task<Domain.Entities.TruckMaster> IRequestHandler<DeleteTruckMaster, Domain.Entities.TruckMaster>.Handle(DeleteTruckMaster request, CancellationToken cancellationToken)
        {
            return await _truckMasterRepository.DeleteTruckMaster(request.Id);

        }
    }
}
