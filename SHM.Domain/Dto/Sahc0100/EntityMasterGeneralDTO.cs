using SHM.Domain.Models.Sahc0106;
using SHM.Domain.Models.Sahc0108;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SHM.Domain.Dto.Sahc0106;


namespace SHM.Domain.Dto.Sahc0100;



public class EntityMasterGeneralDTO
{


    public Guid EntityMasterGeneralKey { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string FirstName { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? MiddleName { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string? LastName { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? MiddleLastName { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? MarriedSurName { get; set; }


    [Column(TypeName = "NVARCHAR(255)")]
    public string? DisplayName { get; set; }


    [Column(TypeName = "NVARCHAR(100)")]
    public string? BusinessName { get; set; }


    public Guid? CountryKey { get; set; }

    
    public string? CountryName { get; set; }


    public DateTime? BirthDay { get; set; }


    [EmailAddress]
    [Column(TypeName = "NVARCHAR(50)")]
    public string? Email { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public int? Type { get; set; }


    [JsonIgnore]
    public string? TypeName
    {
        get
        {
            return Type switch
            {
                0 => "Persona Natural",
                1 => "Compañia",
                _ => TypeName
            };
        }
        set
        {
            TypeName = value;
        }
    }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public int? IdType { get; set; }

    [JsonIgnore]
    public string? IdTypeName
    {
        get
        {
            return IdType switch
            {
                0 => "Cedula",
                1 => "Pasaporte",
                2 => "Ruc",
                3 => "Otro",
                _ => IdTypeName
            };
        }
        set
        {
            IdTypeName = value;
        }
    }


    [Column(TypeName = "NVARCHAR(100)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string? TaxId { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? TaxId1 { get; set; }


    public int? Gender { get; set; }

    [JsonIgnore]
    public string? GenderName
    {
        get
        {
            return Gender switch
            {
                0 => "Masculino",
                1 => "Femenino",
                2 => "No definir",
                _ => GenderName
            };
        }
        set
        {
            GenderName = value;
        }
    }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? Mobile { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? ResidenceTelephone { get; set; }
    public DateTime? ApcDate { get; set; }

    public Guid? EntityMasterGroupKey { get; set; }

    public Guid? CivilStatusKey { get; set; }
    public string? CivilStatusName { get; set; }



    public DateTime? Created { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public Guid? ModifiedBy { get; set; }


    public bool? HighRisk { get; set; }

    public DateTime? ArrangementDate { get; set; }

    [Column(TypeName = "NVARCHAR(250)")]
    public string Comments { get; set; }

    public Guid? B2CKey { get; set; }

    [Column(TypeName = "NVARCHAR(100)")]
    public String? B2CUser { get; set; }

    public bool? GenerarEstadoCuenta { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? MobileCountryKey { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? Telephone { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? TelephoneCountryKey { get; set; }

    public bool? IsDeceased { get; set; }
    public bool? Status { get; set; }



    //Campos agregados en 2024/Abril 
    public int? StatusAccountStatement { get; set; }
    public bool? HasCreditCard { get; set; }
    public bool? HasMerchandiseClub { get; set; }



    public virtual ICollection<EntityMasterAddressDTO> EntityMasterAddressesDTO { get; set; } = new List<EntityMasterAddressDTO>();

    public virtual ICollection<CreditCardMasterGeneralDTO> CreditCardMasterGeneralsDTO { get; set; } = new List<CreditCardMasterGeneralDTO>();

}



/// <summary>
/// Clase para obtener el Get problema al mepear la propiedades
/// TypeName, IdType, GenderName, 
/// </summary>
public class EntityMasterGeneralGetDTO
{


    public Guid? EntityMasterGeneralKey { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string FirstName { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? MiddleName { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string? LastName { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? MiddleLastName { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? MarriedSurName { get; set; }


    [Column(TypeName = "NVARCHAR(255)")]
    public string? DisplayName { get; set; }


    [Column(TypeName = "NVARCHAR(100)")]
    public string? BusinessName { get; set; }


    public Guid? CountryKey { get; set; }


    public string? CountryName { get; set; }


    public DateTime? BirthDay { get; set; }


    [EmailAddress]
    [Column(TypeName = "NVARCHAR(50)")]
    public string? Email { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public int? Type { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public int? IdType { get; set; }


    [Column(TypeName = "NVARCHAR(100)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string? TaxId { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? TaxId1 { get; set; }


    public int? Gender { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? Mobile { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? ResidenceTelephone { get; set; }

    public DateTime? ApcDate { get; set; }

    public Guid? EntityMasterGroupKey { get; set; }

    public Guid? CivilStatusKey { get; set; }



    public DateTime? Created { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public Guid? ModifiedBy { get; set; }
    


    public bool? HighRisk { get; set; }
    public DateTime? ArrangementDate { get; set; }
    
    [Column(TypeName = "NVARCHAR(250)")]
    public string Comments { get; set; }
    public Guid? B2CKey { get; set; }
    public String? B2CUser { get; set; }

    public bool CreateB2CUser { get; set; }

    public string? B2CPassword { get; set; }

    public bool? GenerarEstadoCuenta { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? MobileCountryKey { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? TelephoneCountryKey { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? Telephone { get; set; }

    public bool? IsDeceased { get; set; }

    public bool? Status { get; set; }




    //Campos agregados en 2024/Abril 
    public int? StatusAccountStatement { get; set; }
    public bool? HasCreditCard { get; set; }
    public bool? HasMerchandiseClub { get; set; }




    public virtual ICollection<EntityMasterAddressDTO> EntityMasterAddressesDTO { get; set; } = new List<EntityMasterAddressDTO>();

    public virtual ICollection<CreditCardMasterGeneralDTO> CreditCardMasterGeneralsDTO { get; set; } = new List<CreditCardMasterGeneralDTO>();

}

public class B2CUserDTO
{

    public Guid? B2CKey { get; set; }

    public String? B2CUser { get; set; }

}

public class EntityMasterAdditionalDataDTO {
    public string? CustomerDisplayName { get; set; }
    public string? AgencyDisplayName { get; set; }
    public string? AgentDisplayName { get; set; }
    public string? GroupId { get; set; }
    public string? GroupDescription { get; set; }
}
