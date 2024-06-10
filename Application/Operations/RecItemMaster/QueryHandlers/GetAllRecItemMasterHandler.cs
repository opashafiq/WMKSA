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
    public class GetAllRecItemMasterHandler : IRequestHandler<GetAllRecItemMaster, ICollection<Domain.Entities.RecItemMaster>>
    {
        private readonly IRecItemMasterRepository _recItemMasterRepository;

        public GetAllRecItemMasterHandler(IRecItemMasterRepository recItemMasterRepository)
        {
            _recItemMasterRepository = recItemMasterRepository;
        }

        public async Task<ICollection<Domain.Entities.RecItemMaster>> Handle(GetAllRecItemMaster request, CancellationToken cancellationToken)
        {
            return await _recItemMasterRepository.GetAll();
        }
    }
}
