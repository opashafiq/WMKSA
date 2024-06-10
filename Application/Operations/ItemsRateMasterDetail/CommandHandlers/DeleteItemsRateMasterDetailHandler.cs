using Application.Abstractions;
using Application.Operations.ItemsRateMasterDetails.Commands;
using Application.Operations.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMasterDetails.CommandHandlers
{
    public class DeleteItemsRateMasterDetailsHandler : IRequestHandler<DeleteItemsRateMasterDetail, Domain.Entities.ItemsRateMasterDetail>
    {
        private readonly IItemsRateMasterDetailsRepository _itemsRateMasterDetailsRepository;


        public DeleteItemsRateMasterDetailsHandler(IItemsRateMasterDetailsRepository itemsRateMasterDetailsRepository)
        {
            _itemsRateMasterDetailsRepository = itemsRateMasterDetailsRepository;
        }

        async Task<Domain.Entities.ItemsRateMasterDetail> IRequestHandler<DeleteItemsRateMasterDetail, Domain.Entities.ItemsRateMasterDetail>.Handle(DeleteItemsRateMasterDetail request, CancellationToken cancellationToken)
        {
            return await _itemsRateMasterDetailsRepository.DeleteItemsRateMasterDetails(request.Id);

        }
    }
}
