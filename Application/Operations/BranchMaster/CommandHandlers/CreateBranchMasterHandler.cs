using Application.Abstractions;
using Application.Operations.BranchMaster.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.BranchMaster.CommandHandlers
{
    public class CreateBranchMasterHandler : IRequestHandler<CreateBranchMaster, Domain.Entities.BranchMaster>
    {
        private readonly IBranchMasterRepository _branchMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateBranchMasterHandler(IBranchMasterRepository branchMasterRepository, IMapper mapper)
        {
            _branchMasterRepository = branchMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.BranchMaster> IRequestHandler<CreateBranchMaster, Domain.Entities.BranchMaster>.Handle(CreateBranchMaster request, CancellationToken cancellationToken)
        {
            // Get The task
            var branchMasterCollectionTask = _branchMasterRepository.GetAll();
            // Await the task to get the collection
            var branchMasterCollection = await branchMasterCollectionTask;
            // Calculate the new BranchCode
            var newBranchCodeSuffix = GenerateNewBranchCode(branchMasterCollection);

            var branchMaster = _mapper.Map<Domain.Entities.BranchMaster>(request);

            string countryPrefix = "";
            string cityPrefix = "";

            // Take 2 character from Country
            if (branchMaster.BranchCountry.Length < 2)
            {
                countryPrefix = branchMaster.BranchCountry.ToUpper();
            }
            else
            {
                countryPrefix = branchMaster.BranchCountry.Substring(0, 2).ToUpper();
            }

            // Take 2 character from City
            if (branchMaster.BranchCity.Length < 3)
            {
                cityPrefix = branchMaster.BranchCity.ToUpper();
            }
            else
            {
                cityPrefix = branchMaster.BranchCity.Substring(0, 3).ToUpper();
            }

            branchMaster.BranchCode = countryPrefix + cityPrefix + newBranchCodeSuffix;

            return await _branchMasterRepository.AddBranchMaster(branchMaster);
        }

        public static string GenerateNewBranchCode(ICollection<Domain.Entities.BranchMaster> collection)
        {
            // Fetch the maximum BranchCode, take rightmost 2 characters, convert to bigint, and add 1
            var maxBranchCodeSuffix = collection
                .Where(item => !string.IsNullOrEmpty(item.BranchCode) && item.BranchCode.Length >= 2)
                .Select(item => item.BranchCode.Substring(item.BranchCode.Length - 2))
                .Select(vendorCodeSuffix => long.TryParse(vendorCodeSuffix, out var result) ? result : 0)
                .DefaultIfEmpty(0)
                .Max() + 1;

            var newBranchCodeSuffix = maxBranchCodeSuffix.ToString().PadLeft(2, '0');
            //var newBranchCode = "SUP" + newBranchCodeSuffix;

            return newBranchCodeSuffix;
        }
    }
}
