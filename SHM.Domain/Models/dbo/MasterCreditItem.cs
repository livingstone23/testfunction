using SHM.Domain.Common;
using SHM.Domain.Enums;
using SHM.Domain.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SHM.Domain.Models.Sahc0108;

namespace SHM.Domain.Models.Dto;

[Table("MasterCreditItem")]
public class MasterCreditItem : BaseDomainModel
{

    public MasterCreditItem()
    {
        Active = true;
        Created = TimeZoneHelperTest.GetPanamaTime();
    }

    //Datos personales
    [Key]
    public Guid MasterCreditItemKey { get; set; }


    //[Required(ErrorMessage = "El {0} es un campo requerido. ")]
    //public int NumEntity { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string FirstName { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? MiddleName { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string LastName { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? MiddleLastName { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]

    public string? MarriedSurName { get; set; }


    [ForeignKey("Country")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CountryKey { get; set; }


    public Country Country { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public DateTime BirthDay { get; set; }


    [EmailAddress]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "NVARCHAR(50)")]
    public string Email { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public TypeIdentification Type { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string TaxId { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Gender Gender { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [RegularExpression(@"^\+\d{1,3}\s?\d{1,14}(\s?\d{1,9})?$", ErrorMessage = "El número de teléfono no es válido.")]
    public string Mobile { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [RegularExpression(@"^\+\d{1,3}\s?\d{1,14}(\s?\d{1,9})?$", ErrorMessage = "El número de teléfono no es válido.")]
    public string? ResidenceTelephone { get; set; }


    [ForeignKey("CivilStatus")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CivilStatusKey { get; set; }


    public CivilStatus CivilStatus { get; set; }



    ////Informacion Residencial
    public MasterCreditItemAddress MasterCreditItemAddres { get; set; } = new MasterCreditItemAddress();



    ////Informacion Laboral
    public MasterCreditItemWorkingInformation MasterCreditItemWorkingInformation { get; set; } = new MasterCreditItemWorkingInformation();



    ////Informacion de Conyugue
    public MasterCreditItemMaritalInformation MasterCreditItemMaritalInformation { get; set; } = new MasterCreditItemMaritalInformation();



    ////Referencias Personales
    public ICollection<MasterCreditItemPersonalReference> MasterCreditItemPersonalReferences { get; set; } = new List<MasterCreditItemPersonalReference>();



    ////Tarjeta adicional
    public ICollection<MasterCreditItemAdditionalCard> MasterCreditItemAdditionalCards { get; set; } = new List<MasterCreditItemAdditionalCard>();



    //Firmas Solicitud
    public bool VerifiedSignature { get; set; }


    //Uso Felix
    [Column(TypeName = "NVARCHAR(50)")]
    public string? ReviewedBy { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? ApprovedBy { get; set; }


    public DateTime? ApprovalDate { get; set; }



}

