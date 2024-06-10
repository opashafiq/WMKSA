using Application.Abstractions;
using Application.Operations.ItemsRateMaster.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMaster.CommandHandlers
{
    public class CreateItemsRateMasterHandler : IRequestHandler<CreateItemsRateMaster, Domain.Entities.ItemsRateMaster>
    {
        private readonly IItemsRateMasterRepository _itemsRateMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateItemsRateMasterHandler(IItemsRateMasterRepository itemsRateMasterRepository, IMapper mapper)
        {
            _itemsRateMasterRepository = itemsRateMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.ItemsRateMaster> IRequestHandler<CreateItemsRateMaster, Domain.Entities.ItemsRateMaster>.Handle(CreateItemsRateMaster request, CancellationToken cancellationToken)
        {
            // Get The task
            var itemsRateMasterCollectionTask = _itemsRateMasterRepository.GetAll();
            // Await the task to get the collection
            var itemsRateMasterCollection = await itemsRateMasterCollectionTask;
            // Calculate the new RateCode
            var newRateCode = GenerateNewRateCode(itemsRateMasterCollection);

            var itemsRateMaster = _mapper.Map<Domain.Entities.ItemsRateMaster>(request);
            itemsRateMaster.RateCode = newRateCode;

            return await _itemsRateMasterRepository.AddItemsRateMaster(itemsRateMaster);
        }


        public static string GenerateNewRateCode(ICollection<Domain.Entities.ItemsRateMaster> collection)
        {
            // Fetch the maximum RateCode, take rightmost 6 characters, convert to bigint, and add 1
            var maxRateCodeSuffix = collection
                .Where(item => !string.IsNullOrEmpty(item.RateCode) && item.RateCode.Length >= 6)
                .Select(item => item.RateCode.Substring(item.RateCode.Length - 6))
                .Select(rateCodeSuffix => long.TryParse(rateCodeSuffix, out var result) ? result : 0)
                .DefaultIfEmpty(0)
                .Max() + 1;

            var newRateCodeSuffix = maxRateCodeSuffix.ToString().PadLeft(6, '0');
            var newRateCode = "IRC" + newRateCodeSuffix;

            return newRateCode;
        }
    }
}
