using SHM.Domain.Common;
using SHM.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SHM.Domain.Models.Sahc0108;

namespace SHM.Domain.Models.Dto;


[Table("MasterCreditItemMaritalInformation")]
public class MasterCreditItemMaritalInformation : BaseDomainModel
{


    [Key]
    public Guid MasterCreditItemMaritalInformationKey { get; set; }


    [ForeignKey("MasterCreditItem")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid MasterCreditItemKey { get; set; }


    public MasterCreditItem MasterCreditItem { get; set; }


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


    [Column(TypeName = "NVARCHAR(100)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string CompanyName { get; set; }


    [Column(TypeName = "NVARCHAR(100)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Post { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public TypeIdentification Type { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string TaxId { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? Mobile { get; set; }


    [EmailAddress]
    [Column(TypeName = "NVARCHAR(50)")]
    public string? Email { get; set; }


    [Column(TypeName = "DECIMAL(10,2)")]
    public decimal? Antiquity { get; set; }


    [Column(TypeName = "DECIMAL(10,2)")]
    public decimal MonthlyIncome { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? OfficePhone { get; set; }


}

