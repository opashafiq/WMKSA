using Application.Abstractions;
using Application.Operations.ItemsRateMaster.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMaster.CommandHandlers
{
    public class DeleteItemsRateMasterHandler : IRequestHandler<DeleteItemsRateMaster, Domain.Entities.ItemsRateMaster>
    {
        private readonly IItemsRateMasterRepository _itemsRateMasterRepository;


        public DeleteItemsRateMasterHandler(IItemsRateMasterRepository itemsRateMasterRepository)
        {
            _itemsRateMasterRepository = itemsRateMasterRepository;
        }

        async Task<Domain.Entities.ItemsRateMaster> IRequestHandler<DeleteItemsRateMaster, Domain.Entities.ItemsRateMaster>.Handle(DeleteItemsRateMaster request, CancellationToken cancellationToken)
        {
            return await _itemsRateMasterRepository.DeleteItemsRateMaster(request.Id);

        }
    }
}
