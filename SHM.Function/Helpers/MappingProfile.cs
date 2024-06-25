using AutoMapper;
using SHM.Domain.Dto.Sahc0100;
using SHM.Domain.Dto.Sahc0108;
using SHM.Domain.Models.Sahc0100;
using SHM.Domain.Models.Sahc0108;

namespace SHM.Function.Helpers;

//public class MappingProfile : Profile
//{
//    public MappingProfile()
//    {
        

//        CreateMap<EntityMasterGeneral, EntityMasterGeneralDTO>()
//            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name))
//            .ForMember(dest => dest.CivilStatusName, opt => opt.MapFrom(src => src.CivilStatus.Name)); 
//        CreateMap<EntityMasterGeneralDTO, EntityMasterGeneral>();


//        CreateMap<EntityMasterAddress, EntityMasterAddressDTO>()
//            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Countries.Name))
//            .ForMember(dest => dest.ProvinceName, opt => opt.MapFrom(src => src.Provinces.Name))
//            .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.Districts.Name))
//            .ForMember(dest => dest.TownshipName, opt => opt.MapFrom(src => src.Townships.Name))
//            .ForMember(dest => dest.SourceMasterName, opt => opt.MapFrom(src => src.SourceMasters.Id))
//            .ForMember(dest => dest.EntityMasterAddressTypeName, opt => opt.MapFrom(src => src.EntityMasterAddresstypes.Id));
//        CreateMap<EntityMasterAddressDTO, EntityMasterAddress>();

//    }


//}

