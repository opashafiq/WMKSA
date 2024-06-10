using Application.Abstractions;
using Application.Operations.RecItemMaster.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.RecItemMaster.CommandHandlers
{
    public class DeleteRecItemMasterHandler : IRequestHandler<DeleteRecItemMaster, Domain.Entities.RecItemMaster>
    {
        private readonly IRecItemMasterRepository _recItemMasterRepository;


        public DeleteRecItemMasterHandler(IRecItemMasterRepository recItemMasterRepository)
        {
            _recItemMasterRepository = recItemMasterRepository;
        }

        async Task<Domain.Entities.RecItemMaster> IRequestHandler<DeleteRecItemMaster, Domain.Entities.RecItemMaster>.Handle(DeleteRecItemMaster request, CancellationToken cancellationToken)
        {
            return await _recItemMasterRepository.DeleteRecItemMaster(request.Id);

        }
    }
}
