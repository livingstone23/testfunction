using AutoMapper;
using SHM.Domain.Dto.Sahc0100;
using SHM.Domain.Dto.Sahc0106;
using SHM.Domain.Models.Sahc0100;
using SHM.Domain.Models.Sahc0106;



namespace SHM.Domain.Helper;



public class MapHelper
{

    private readonly IMapper _mapper;


    public MapHelper(IMapper mapper)
    {
        _mapper = mapper;

    }

    public void MapCreditRequestMasterDetailDTO(CreditRequestMasterDTO creditoRequestMasterDTO, ICollection<CreditRequestMasterDetail> newCreditoDetailDTOs)
    {
        foreach (CreditRequestMasterDetail reg in newCreditoDetailDTOs)
        {
            creditoRequestMasterDTO.CreditRequestMasterDetailDTOs.Add(_mapper.Map<CreditRequestMasterDetailDTO>(reg));

            if (reg.CreditRequestPersonalReferences.Any())
            {
                foreach (CreditRequestPersonalReference data in reg.CreditRequestPersonalReferences)
                {
                    var MasterDetail = creditoRequestMasterDTO.CreditRequestMasterDetailDTOs.Where(r => r.CreditRequestMasterDetailKey == data.CreditRequestMasterDetailKey).FirstOrDefault();
                    MasterDetail.CreditRequestPersonalReferencesDTO.Add(_mapper.Map<CreditRequestPersonalReferenceDTO>(data));
                }
            }

            if (reg.CreditRequestWorkingInformations.Any())
            {
                foreach (CreditRequestWorkingInformation data in reg.CreditRequestWorkingInformations)
                {
                    var MasterDetail = creditoRequestMasterDTO.CreditRequestMasterDetailDTOs.Where(r => r.CreditRequestMasterDetailKey == data.CreditRequestMasterDetailKey).FirstOrDefault();
                    MasterDetail.CreditRequestWorkingInformationsDTO.Add(_mapper.Map<CreditRequestWorkingInformationDTO>(data));
                }
            }

            if (reg.EntityMasterAddres != null)
            {
                var MasterDetail = creditoRequestMasterDTO.CreditRequestMasterDetailDTOs.Where(r => r.CreditRequestMasterDetailKey == reg.CreditRequestMasterDetailKey).FirstOrDefault();
                MasterDetail.EntityMasterAddressDTO = _mapper.Map<EntityMasterAddressDTO>(reg.EntityMasterAddres);







            }

        }
    }

    public void MapCreditCardMasterGeneralDTO(EntityMasterGeneralDTO entityMasterGeneralDTO, ICollection<CreditCardMasterGeneral> newCreditCardMasterGeneral)
    {
        foreach (CreditCardMasterGeneral reg in newCreditCardMasterGeneral)
        {
            
            entityMasterGeneralDTO.CreditCardMasterGeneralsDTO.Add(_mapper.Map<CreditCardMasterGeneralDTO>(reg));


            if (reg.CreditCardBalances is not null)
            {

                //foreach (CreditCardBalance data in reg.CreditCardBalances)
                //{
                //    var CreditCardMaster = entityMasterGeneralDTO.CreditCardMasterGeneralsDTO.Where(r => r.CreditCardMasterGeneralKey == data.CreditCardMasterGeneralKey).FirstOrDefault();
                //    CreditCardMaster.CreditCardBalancesDTO.Add(_mapper.Map<CreditCardBalanceDTO>(data));

                //}

            }

        }
    }

    public void MapEntityMasterGeneral(EntityMasterGeneralGetDTO entityMasterGeneral, ICollection<EntityMasterAddress>  entityMasterAddresses)
    {
        foreach (EntityMasterAddress reg in entityMasterAddresses)
        {

            entityMasterGeneral.EntityMasterAddressesDTO.Add(_mapper.Map<EntityMasterAddressDTO>(reg));

        }
    }

    public void CreateNewCreditRequestMasterDetail(CreditRequestMaster creditRequestMater, ICollection<CreditRequestMasterDetailDTO> newCreditDetails)
    {
        foreach (CreditRequestMasterDetailDTO reg in newCreditDetails)
        {
            reg.CreditRequestMasterKey = creditRequestMater.CreditRequestMasterKey;
            reg.CreditRequestMasterDetailKey = Guid.NewGuid();
            reg.Created = TimeZoneHelperTest.GetPanamaTime();
            creditRequestMater.CreditRequestMasterDetails.Add(_mapper.Map<CreditRequestMasterDetail>(reg));
        }
    }

    public void NewCreditRequestPersonalReference(CreditRequestMasterDetail requestMasterDetail, ICollection<CreditRequestPersonalReferenceDTO> personalReferences)
    {
        foreach (CreditRequestPersonalReferenceDTO reg in personalReferences)
        {
            reg.CreditRequestMasterDetailKey = requestMasterDetail.CreditRequestMasterDetailKey;
            reg.CreditRequestPersonalReferenceKey = Guid.NewGuid();
            reg.Created = TimeZoneHelperTest.GetPanamaTime();
            requestMasterDetail.CreditRequestPersonalReferences.Add(_mapper.Map<CreditRequestPersonalReference>(reg));
        }
    }


    public void NewCreditRequestWorkingInformation(CreditRequestMasterDetail requestMasterDetail, ICollection<CreditRequestWorkingInformationDTO> workReference)
    {
        foreach (CreditRequestWorkingInformationDTO reg in workReference)
        {
            reg.CreditRequestMasterDetailKey = requestMasterDetail.CreditRequestMasterDetailKey;
            reg.CreditRequestWorkingInformationKey = Guid.NewGuid();
            reg.Created = TimeZoneHelperTest.GetPanamaTime();
            requestMasterDetail.CreditRequestWorkingInformations.Add(_mapper.Map<CreditRequestWorkingInformation>(reg));
        }
    }
    

    public string GetMessageSinRegistros()
    {
        return "No existen Registros";
    }


    public async Task<String> GetRoute(string routeSchema,string paramName)
    {
        try
        {

            return $"{routeSchema}{paramName}";

        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

}



