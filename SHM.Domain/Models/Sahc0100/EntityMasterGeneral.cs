using SHM.Domain.Models.Sahc0108;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SHM.Domain.Models.Sahc0106;


namespace SHM.Domain.Models.Sahc0100;



[Table("EntityMasterGeneral", Schema = "Sahc0100")]
public class EntityMasterGeneral
{
    
    [Key]
    public Guid EntityMasterGeneralKey { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string? FirstName { get; set; }

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
    

    [ForeignKey("Country")]
    //[Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CountryKey { get; set; }
    public Country Country { get; set; }

    
    public DateTime? BirthDay { get; set; }


    [EmailAddress]
    [Column(TypeName = "NVARCHAR(50)")]
    public string? Email { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public int Type { get; set; }
    
    
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public int IdType { get; set; }
    
    
    [Column(TypeName = "NVARCHAR(100)")]
    
    public string? TaxId { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? TaxId1 { get; set; }
    
    
    public int? Gender { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? MobileCountryKey { get; set; }
    
    [Column(TypeName = "NVARCHAR(50)")]
    public string? Mobile { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? TelephoneCountryKey { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? Telephone { get; set; }

    public DateTime? ApcDate { get; set; }

    public Guid? EntityMasterGroupKey { get; set; }

    [ForeignKey("CivilStatus")]
    //[Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CivilStatusKey { get; set; }
    public CivilStatus CivilStatus { get; set; }

    public Guid? B2CKey { get; set; }
    [Column(TypeName = "NVARCHAR(100)")]
    public String? B2CUser { get; set; }

    public bool? HighRisk { get; set; }
    public DateTime? ArrangementDate { get; set; }

    [Column(TypeName = "NVARCHAR(250)")]
    public string? Comments { get; set; }


    
    public DateTime? Created { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public Guid? ModifiedBy { get; set; }


    public bool? IsDeceased { get; set; }
    public bool? Status { get; set; }



    public string? OfficePhone { get; set; }
    public string? OfficePhoneCountryKey { get; set; }

    public DateTime? OpeningDate { get; set; }

    public bool? GenerarEstadoCuenta { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? ResidenceTelephone { get; set; }





    /// <summary>
    /// Campos agregados en 2024/Abril 
    /// </summary>
    public int? StatusAccountStatement { get; set; }
    public bool? HasCreditCard { get; set; }
    public bool? HasMerchandiseClub { get; set; }





    public virtual ICollection<EntityMasterAddress>? EntityMasterAddresses { get; set; } = new List<EntityMasterAddress>();

    public virtual ICollection<CreditCardMasterGeneral>? CreditCardMasterGenerals { get; set; } = new List<CreditCardMasterGeneral>();


}

