using Application.Abstractions;
using Application.Operations.TransporterMaster.Commands;
using Application.Operations.Person.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.TransporterMaster.CommandHandlers
{
    public class CreateTransporterMasterHandler : IRequestHandler<CreateTransporterMaster, Domain.Entities.TransporterMaster>
    {
        private readonly ITransporterMasterRepository _transporterMasterRepository;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CreateTransporterMasterHandler(ITransporterMasterRepository transporterMasterRepository, IMapper mapper)
        {
            _transporterMasterRepository = transporterMasterRepository;
            _mapper = mapper;
        }



        async Task<Domain.Entities.TransporterMaster> IRequestHandler<CreateTransporterMaster, Domain.Entities.TransporterMaster>.Handle(CreateTransporterMaster request, CancellationToken cancellationToken)
        {
            // Get The task
            var transporterMasterCollectionTask = _transporterMasterRepository.GetAll();
            // Await the task to get the collection
            var transporterMasterCollection = await transporterMasterCollectionTask;
            // Calculate the new TransporterCode
            var newTransporterCodePrefix = GenerateNewTransporterCode(transporterMasterCollection);

            var transporterMaster = _mapper.Map<Domain.Entities.TransporterMaster>(request);

            if (transporterMaster.TransCode.Length == null)
            {
                transporterMaster.TransCode = newTransporterCodePrefix;
            }
            else if (transporterMaster.TransCode.Length <= 2)
            {
                transporterMaster.TransCode = transporterMaster.TransName.ToUpper() + newTransporterCodePrefix;
            }
            else
            {
                transporterMaster.TransCode = transporterMaster.TransName.Substring(0, 3).ToUpper() + newTransporterCodePrefix;
            }

            return await _transporterMasterRepository.AddTransporterMaster(transporterMaster);
        }

        public static string GenerateNewTransporterCode(ICollection<Domain.Entities.TransporterMaster> collection)
        {
            // Fetch the maximum TransporterCode, take rightmost 4 characters, convert to bigint, and add 1
            var maxTransporterCodeSuffix = collection
                .Where(item => !string.IsNullOrEmpty(item.TransCode) && item.TransCode.Length >= 4)
                .Select(item => item.TransCode.Substring(item.TransCode.Length - 4))
                .Select(vendorCodeSuffix => long.TryParse(vendorCodeSuffix, out var result) ? result : 0)
                .DefaultIfEmpty(0)
                .Max() + 1;

            var newTransporterCodeSuffix = maxTransporterCodeSuffix.ToString().PadLeft(4, '0');
            //var newTransporterCode = "SUP" + newTransporterCodeSuffix;

            return newTransporterCodeSuffix;
        }
    }
}
