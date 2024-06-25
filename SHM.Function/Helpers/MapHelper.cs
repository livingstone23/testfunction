using AutoMapper;
using SHM.Domain.Dto.Sahc0100;
using SHM.Domain.Dto.Sahc0106;
using SHM.Domain.Models.Sahc0100;
using SHM.Domain.Models.Sahc0106;
using System.Collections.Generic;
using System.Linq;



namespace Sahc0100.Helpers;



//public class MapHelper
//{

//    private readonly IMapper _mapper;


//    public MapHelper(IMapper mapper)
//    {
//        _mapper = mapper;

//    }

//    public void MapCreditRequestMasterDetailDTO(CreditRequestMasterDTO creditoRequestMasterDTO, ICollection<CreditRequestMasterDetail> newCreditoDetailDTOs)
//    {
//        foreach (CreditRequestMasterDetail reg in newCreditoDetailDTOs)
//        {
//            creditoRequestMasterDTO.CreditRequestMasterDetailDTOs.Add(_mapper.Map<CreditRequestMasterDetailDTO>(reg));

//            if (reg.CreditRequestPersonalReferences.Any())
//            {
//                foreach (CreditRequestPersonalReference data in reg.CreditRequestPersonalReferences)
//                {
//                    var MasterDetail = creditoRequestMasterDTO.CreditRequestMasterDetailDTOs.Where(r => r.CreditRequestMasterDetailKey == data.CreditRequestMasterDetailKey).FirstOrDefault();
//                    MasterDetail.CreditRequestPersonalReferencesDTO.Add(_mapper.Map<CreditRequestPersonalReferenceDTO>(data));
//                }
//            }

//            if (reg.CreditRequestWorkingInformations.Any())
//            {
//                foreach (CreditRequestWorkingInformation data in reg.CreditRequestWorkingInformations)
//                {
//                    var MasterDetail = creditoRequestMasterDTO.CreditRequestMasterDetailDTOs.Where(r => r.CreditRequestMasterDetailKey == data.CreditRequestMasterDetailKey).FirstOrDefault();
//                    MasterDetail.CreditRequestWorkingInformationsDTO.Add(_mapper.Map<CreditRequestWorkingInformationDTO>(data));
//                }
//            }

//        }
//    }

//    public void MapEntityMasterGeneral(EntityMasterGeneralDTO entityMasterGeneral, ICollection<EntityMasterAddress> entityMasterAddresses)
//    {
//        foreach (EntityMasterAddress reg in entityMasterAddresses)
//        {

//            entityMasterGeneral.EntityMasterAddressesDTO.Add(_mapper.Map<EntityMasterAddressDTO>(reg));

//        }
//    }


//}

