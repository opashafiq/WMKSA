using Application.Authentication.Commands.Login;
using Application.Common.Dtos;
using Application.Operations.BranchMaster.Commands;
using Application.Operations.CustomerMaster.Commands;
using Application.Operations.SubCustomerMaster.Commands;
using Application.Operations.DriverMaster.Commands;
using Application.Operations.ItemService.Commands;
using Application.Operations.ItemsRateMaster.Commands;
using Application.Operations.ItemsRateMasterDetails.Commands;
using Application.Operations.PackageMaster.Commands;
using Application.Operations.Person.Commands;
using Application.Operations.RecItemMaster.Commands;
using Application.Operations.TransporterMaster.Commands;
using Application.Operations.TruckMaster.Commands;
using Application.Operations.UnitMaster.Commands;
using Application.Operations.VendorMaster.Commands;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Operations.JobOrder.Commands;
using Application.Operations.ReceiveItemsNew.Commands;
using Application.Operations.ReceiveItemsNewDetail.Commands;
using Application.Operations.ReceiveItemsNewRelease.Commands;
using Application.Operations.ReceiveItemsNewReleaseDetail.Commands;

namespace Application.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<CreatePerson, Domain.Entities.Person>();
            CreateMap<CreateBranchMaster, Domain.Entities.BranchMaster>();
            CreateMap<UpdateBranchMaster, Domain.Entities.BranchMaster>();
            CreateMap<CreateCustomerMaster, Domain.Entities.CustomerMaster>();
            CreateMap<UpdateCustomerMaster, Domain.Entities.CustomerMaster>();
            CreateMap<CreateSubCustomerMaster, Domain.Entities.SubCustomerMaster>();
            CreateMap<UpdateSubCustomerMaster, Domain.Entities.SubCustomerMaster>();
            CreateMap<CreateVendorMaster, Domain.Entities.VendorMaster>();
            CreateMap<UpdateVendorMaster, Domain.Entities.VendorMaster>();
            CreateMap<CreateTransporterMaster, Domain.Entities.TransporterMaster>();
            CreateMap<UpdateTransporterMaster, Domain.Entities.TransporterMaster>();
            CreateMap<CreateTruckMaster, Domain.Entities.TruckMaster>();
            CreateMap<UpdateTruckMaster, Domain.Entities.TruckMaster>();
            CreateMap<CreateDriverMaster, Domain.Entities.DriverMaster>();
            CreateMap<UpdateDriverMaster, Domain.Entities.DriverMaster>();
            CreateMap<CreatePackageMaster, Domain.Entities.PackageMaster>();
            CreateMap<UpdatePackageMaster, Domain.Entities.PackageMaster>();
            CreateMap<CreateUnitMaster, Domain.Entities.UnitMaster>();
            CreateMap<UpdateUnitMaster, Domain.Entities.UnitMaster>();
            CreateMap<CreateRecItemMaster, Domain.Entities.RecItemMaster>();
            CreateMap<UpdateRecItemMaster, Domain.Entities.RecItemMaster>();
            CreateMap<CreateItemService, Domain.Entities.ItemService>();
            CreateMap<UpdateItemService, Domain.Entities.ItemService>();
            CreateMap<CreateItemsRateMaster, Domain.Entities.ItemsRateMaster>();
            CreateMap<UpdateItemsRateMaster, Domain.Entities.ItemsRateMaster>();
            CreateMap<CreateItemsRateMasterDetail, Domain.Entities.ItemsRateMasterDetail>();
            CreateMap<UpdateItemsRateMasterDetail, Domain.Entities.ItemsRateMasterDetail>();
            CreateMap<CreateJobOrder, Domain.Entities.JobOrder>();
            CreateMap<UpdateJobOrder, Domain.Entities.JobOrder>();
            CreateMap<CreateReceiveItemsNew, Domain.Entities.ReceiveItemsNew>();
            CreateMap<UpdateReceiveItemsNew, Domain.Entities.ReceiveItemsNew>();
            CreateMap<CreateReceiveItemsNewDetail, Domain.Entities.ReceiveItemsNewDetail>();
            CreateMap<UpdateReceiveItemsNewDetail, Domain.Entities.ReceiveItemsNewDetail>();
            CreateMap<CreateReceiveItemsNewRelease, Domain.Entities.ReceiveItemsNewRelease>();
            CreateMap<UpdateReceiveItemsNewRelease, Domain.Entities.ReceiveItemsNewRelease>();
            CreateMap<CreateReceiveItemsNewReleaseDetail, Domain.Entities.ReceiveItemsNewReleaseDetail>();
            CreateMap<UpdateReceiveItemsNewReleaseDetail, Domain.Entities.ReceiveItemsNewReleaseDetail>();


            // Map Dtos
            CreateMap<Domain.Entities.DriverMaster, DriverMasterKeyValueDto>();
            CreateMap<Domain.Entities.TransporterMaster, TransporterMasterKeyValueDto>();
            CreateMap<Domain.Entities.ItemService, ItemServiceKeyValueDto>();
            CreateMap<Domain.Entities.ItemsRateMaster, ItemsRateMasterKeyValueDto>();
            CreateMap<Domain.Entities.RecItemMaster, RecItemMasterKeyValueDto>();
            CreateMap<Domain.Entities.UnitMaster, UnitMasterKeyValueDto>();

            //ViewModels
            //CreateMap<Domain.Entities.TruckMaster, TruckMasterDto>();

            CreateMap<Domain.Entities.TruckMaster, TruckMasterDto>()
                .ForMember(dest => dest.TransporterMasterTransCode, opt => opt.MapFrom(src => src.TranspoterMaster.TransCode))
                .ForMember(dest => dest.TransporterMasterTransName, opt => opt.MapFrom(src => src.TranspoterMaster.TransName));
                
        }
    }
}
