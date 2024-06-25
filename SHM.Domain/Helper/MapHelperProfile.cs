using AutoMapper;
using SHM.Domain.Dto.Sahc0100;
using SHM.Domain.Dto.Sahc0104;
using SHM.Domain.Dto.Sahc0106;
using SHM.Domain.Dto.Sahc0108;
using SHM.Domain.Dto.Sahc0109;
using SHM.Domain.Models.Sahc0100;
using SHM.Domain.Models.Sahc0104;
using SHM.Domain.Models.Sahc0106;
using SHM.Domain.Models.Sahc0108;
using SHM.Domain.Models.Sahc0109;


namespace SHM.Domain.Helper;



public class MapHelperProfile : Profile
{

    public MapHelperProfile()
    {
        //Esquema 100
        CreateMap<EntityMasterGeneral, EntityMasterGeneralDTO>()
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name))
            .ForMember(dest => dest.CivilStatusName, opt => opt.MapFrom(src => src.CivilStatus.Name));
        CreateMap<EntityMasterGeneralDTO, EntityMasterGeneral>();
        CreateMap<EntityMasterGeneralGetDTO, EntityMasterGeneral>();
        CreateMap< EntityMasterGeneral,EntityMasterGeneralGetDTO>();

        CreateMap<EntityMasterAddress, EntityMasterAddressDTO>()
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Countries.Name))
            .ForMember(dest => dest.ProvinceName, opt => opt.MapFrom(src => src.Provinces.Name))
            .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.Districts.Name))
            .ForMember(dest => dest.TownshipName, opt => opt.MapFrom(src => src.Townships.Name))
            .ForMember(dest => dest.SourceMasterName, opt => opt.MapFrom(src => src.SourceMasters.Id))
            .ForMember(dest => dest.EntityMasterAddressTypeName, opt => opt.MapFrom(src => src.EntityMasterAddresstypes.Id));
        CreateMap<EntityMasterAddressDTO, EntityMasterAddress>();


        CreateMap<EntityMasterGeneralGetDTO, EntityMasterGeneralDTO>();

        //Esquema 106
        CreateMap<CreditRequestMaster, CreditRequestMasterDTO>()
            .ForMember(dest => dest.ReasonRequestTypeName, opt => opt.MapFrom(src => src.ReasonRequestTypes.Description));
        CreateMap<CreditRequestMasterDTO, CreditRequestMaster>();


        CreateMap<CreditRequestMasterDetail, CreditRequestMasterDetailDTO>()
            .ForMember(dest => dest.RelationshipTypeName, opt => opt.MapFrom(src => src.RelationshipTypes.Name)); ;
        CreateMap<CreditRequestMasterDetailDTO, CreditRequestMasterDetail>();


        CreateMap<CreditRequestPersonalReference, CreditRequestPersonalReferenceDTO>();
        CreateMap<CreditRequestPersonalReferenceDTO, CreditRequestPersonalReference>();


        CreateMap<CreditRequestWorkingInformation, CreditRequestWorkingInformationDTO>();
        CreateMap<CreditRequestWorkingInformationDTO, CreditRequestWorkingInformation>();


        CreateMap<ReasonRequestType, ReasonRequestTypeDTO>();
        CreateMap<ReasonRequestTypeDTO, ReasonRequestType>();


        CreateMap<CreditCardMasterGeneral, CreditCardMasterGeneralDTO>();
        CreateMap<CreditCardMasterGeneralDTO, CreditCardMasterGeneral>();


        CreateMap<CreditCardBalance, CreditCardBalanceDTO>();
        CreateMap<CreditCardBalanceDTO, CreditCardBalance>();


        CreateMap<CreditCardProfile, CreditCardProfileDTO>();
        CreateMap<CreditCardProfileDTO, CreditCardProfile>();


        CreateMap<CreditCardAccountStatement, CreditCardAccountStatementDTO>();
        CreateMap<CreditCardAccountStatementDTO, CreditCardAccountStatement>();


        CreateMap<CreditCardTransactions, CreditCardTransactionsDTO>();
        CreateMap<CreditCardTransactionsDTO, CreditCardTransactions>();





        CreateMap<CreditCardTransactionProcessor, CreditCardTransactionProcessorDTO>();
        CreateMap<CreditCardTransactionProcessorDTO, CreditCardTransactionProcessor>();

        CreateMap<CreditCardTransactionProcessorDetail, CreditCardTransactionProcessorDetailDTO>();
        CreateMap<CreditCardTransactionProcessorDetailDTO, CreditCardTransactionProcessorDetail>();

        CreateMap<CreditCardTransactionProcessorLog, CreditCardTransactionProcessorLogDTO>();
        CreateMap<CreditCardTransactionProcessorLogDTO, CreditCardTransactionProcessorLog>();

        CreateMap<CreditCardTranProcessorCycle, CreditCardTranProcessorCycleDTO>();
        CreateMap<CreditCardTranProcessorCycleDTO, CreditCardTranProcessorCycle>();

        CreateMap<CreditCardTranProcessorCycleLog, CreditCardTranProcessorCycleLogDTO>();
        CreateMap<CreditCardTranProcessorCycleLogDTO, CreditCardTranProcessorCycleLog>();

        CreateMap<CreditCardTransactionsType, CreditCardTransactionsTypeDTO>();
        CreateMap<CreditCardTransactionsTypeDTO, CreditCardTransactionsType>();



        CreateMap<CreditCardMasterStatus, CreditCardMasterStatusDTO>();
        CreateMap<CreditCardMasterStatusDTO, CreditCardMasterStatus>();

        CreateMap<CreditCardStatus, CreditCardStatusDTO>();
        CreateMap<CreditCardStatusDTO, CreditCardStatus>();





        CreateMap<CatalogGeneric, CatalogGenericDTO>();
        CreateMap<CatalogGenericDTO, CatalogGeneric>();
        CreateMap<CatalogGeneric, CatalogGenericToDropDownDTO>()
            .ForMember(dest => dest.CatalogKey, opt => opt.MapFrom(src => src.CatalogGenericKey)); ;


        CreateMap<CreditCardList, CreditCardListDTO>();
        CreateMap<CreditCardListDTO, CreditCardList>();


        CreateMap<CreditCardStatus, CreditCardStatusDTO>();
        CreateMap<CreditCardStatusDTO, CreditCardStatus>();


        //Esquema
        CreateMap<SourceMaster, SourceMasterDTO>();
        CreateMap<SourceMasterDTO, SourceMaster>();


        CreateMap<CivilStatus, CivilStatusDTO>();
        CreateMap<CivilStatusDTO, CivilStatus>();


        CreateMap<RelationshipType, RelationshipTypeDTO>();
        CreateMap<RelationshipTypeDTO, RelationshipType>();


        CreateMap<Country, CountryDTO>();
        CreateMap<CountryDTO, Country>();


        CreateMap<Province, ProvinceDTO>();
        CreateMap<ProvinceDTO, Province>();


        CreateMap<District, DistrictDTO>();
        CreateMap<DistrictDTO, District>();


        CreateMap<Township, TownshipDTO>();
        CreateMap<TownshipDTO, Township>();
        

        CreateMap<TranslationCatalogDTO, TranslationCatalog>();
        CreateMap<TranslationCatalog, TranslationCatalogDTO>();
        CreateMap<TranslationCatalog, TranslationCatalogDropDownDTO>();

        CreateMap<CatalogVersion, CatalogVersionDTO>();
        CreateMap<CatalogVersionDTO, CatalogVersion>();

        CreateMap<DataImport, DataImportDTO>();
        CreateMap<DataImportDTO, DataImport>();



    }


}

