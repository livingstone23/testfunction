using SHM.Domain.Common;
using SHM.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHM.Domain.Dto.dbo;

public class MasterCreditItemDTO : BaseDomainModel
{
    public MasterCreditItemDTO()
    {
        Active = true;
    }

    public Guid MasterCreditItemKey { get; set; }


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


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CountryKey { get; set; }


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
    //[RegularExpression(@"^\+\d{1,3}\s?\d{1,14}(\s?\d{1,9})?$", ErrorMessage = "El número de teléfono no es válido.")]
    public string Mobile { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    //[RegularExpression(@"^\+\d{1,3}\s?\d{1,14}(\s?\d{1,9})?$", ErrorMessage = "El número de teléfono no es válido.")]
    public string? ResidenceTelephone { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CivilStatusKey { get; set; }


    public bool VerifiedSignature { get; set; }


    //Uso Felix
    [Column(TypeName = "NVARCHAR(50)")]
    public string? ReviewedBy { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? ApprovedBy { get; set; }


    public DateTime? ApprovalDate { get; set; }


    [Required(ErrorMessage = "La Seccion {0} es requerida. ")]
    public MasterCreditItemAddressDTO MasterCreditItemAddres { get; set; }


    public MasterCreditItemWorkingInformationDTO MasterCreditItemWorkingInformation { get; set; }


    public MasterCreditItemMaritalInformationDTO MasterCreditItemMaritalInformation { get; set; }


    [Required(ErrorMessage = "La Seccion {0} es requerida. ")]
    public ICollection<MasterCreditItemPersonalReferenceDTO> MasterCreditItemPersonalReferencesDTO { get; set; } = new List<MasterCreditItemPersonalReferenceDTO>();


    public ICollection<MasterCreditItemAdditionalCardDTO> MasterCreditItemAdditionalCardsDTO { get; set; } = new List<MasterCreditItemAdditionalCardDTO>();


}