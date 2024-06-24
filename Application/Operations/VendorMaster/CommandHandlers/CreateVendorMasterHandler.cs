using Application.Abstractions;
using Application.Operations.VendorMaster.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Operations.VendorMaster.CommandHandlers
{
    public class CreateVendorMasterHandler : IRequestHandler<CreateVendorMaster, Domain.Entities.VendorMaster>
    {
        private readonly IVendorMasterRepository _vendorMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateVendorMasterHandler(IVendorMasterRepository vendorMasterRepository, IMapper mapper)
        {
            _vendorMasterRepository = vendorMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.VendorMaster> IRequestHandler<CreateVendorMaster, Domain.Entities.VendorMaster>.Handle(CreateVendorMaster request, CancellationToken cancellationToken)
        {
            // Get The task
            var vendorMasterCollectionTask = _vendorMasterRepository.GetAll();
            // Await the task to get the collection
            var vendorMasterCollection = await vendorMasterCollectionTask;
            // Calculate the new VendorCode
            var newVendorCode = GenerateNewVendorCode(vendorMasterCollection);

            var vendorMaster = _mapper.Map<Domain.Entities.VendorMaster>(request);
            vendorMaster.VendorCode = newVendorCode;
            return await _vendorMasterRepository.AddVendorMaster(vendorMaster);
        }

        public static string GenerateNewVendorCode(ICollection<Domain.Entities.VendorMaster> collection)
        {
            // Fetch the maximum VendorCode, take rightmost 5 characters, convert to bigint, and add 1
            var maxVendorCodeSuffix = collection
                .Where(item => !string.IsNullOrEmpty(item.VendorCode) && item.VendorCode.Length >= 5)
                .Select(item => item.VendorCode.Substring(item.VendorCode.Length - 5))
                .Select(vendorCodeSuffix => long.TryParse(vendorCodeSuffix, out var result) ? result : 0)
                .DefaultIfEmpty(0)
                .Max() + 1;

            var newVendorCodeSuffix = maxVendorCodeSuffix.ToString().PadLeft(5, '0');
            var newVendorCode = "SUP" + newVendorCodeSuffix;

            return newVendorCode;
        }

    }
}
