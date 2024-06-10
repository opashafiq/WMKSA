using Application.Abstractions;
using Application.Operations.RecItemMaster.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.RecItemMaster.QueryHandlers
{
    public class GetRecItemMasterByIdHandler : IRequestHandler<GetRecItemMasterById, Domain.Entities.RecItemMaster>
    {
        private readonly IRecItemMasterRepository _recItemMasterRepository;

        public GetRecItemMasterByIdHandler(IRecItemMasterRepository recItemMasterRepository)
        {
            _recItemMasterRepository = recItemMasterRepository;
        }

        public async Task<Domain.Entities.RecItemMaster> Handle(GetRecItemMasterById request, CancellationToken cancellationToken)
        {
            return await _recItemMasterRepository.GetRecItemMasterById(request.Id);
        }
    }
}
