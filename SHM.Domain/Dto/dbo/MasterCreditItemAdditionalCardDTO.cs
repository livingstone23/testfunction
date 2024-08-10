using SHM.Domain.Common;
using SHM.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHM.Domain.Dto.dbo;

public class MasterCreditItemAdditionalCardDTO : BaseDomainModel
{
    public MasterCreditItemAdditionalCardDTO()
    {
        Active = true;
    }
    public Guid MasterCreditItemAdditionalCardKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
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


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CountryKey { get; set; }


    public DateTime? BirthDay { get; set; }


    [EmailAddress]
    [Column(TypeName = "NVARCHAR(50)")]
    public string? Email { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public TypeIdentification Type { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string TaxId { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Gender Gender { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Mobile { get; set; }



    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? RelationshipKey { get; set; }



    [Column(TypeName = "NVARCHAR(50)")]
    public string? Phone { get; set; }


}