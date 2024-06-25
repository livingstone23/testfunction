using SHM.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHM.Domain.Dto.dbo;

public class MasterCreditItemWorkingInformationDTO : BaseDomainModel
{
    public MasterCreditItemWorkingInformationDTO()
    {
        Active = true;
    }
    public Guid MasterWorkingInformationKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid MasterCreditItemKey { get; set; }


    [Column(TypeName = "NVARCHAR(100)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string CompanyName { get; set; }


    [Column(TypeName = "NVARCHAR(100)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Post { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public DateTime AdmissionDate { get; set; }


    [Column(TypeName = "NVARCHAR(200)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string WorkAddress { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? OfficePhone { get; set; }


    [Column(TypeName = "DECIMAL(10,2)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public decimal BaseSalary { get; set; }


    [Column(TypeName = "DECIMAL(10,2)")]
    public decimal? OtherIncome { get; set; }


    [Column(TypeName = "NVARCHAR(200)")]
    public string? Detail { get; set; }

    [EmailAddress]
    [Column(TypeName = "NVARCHAR(100)")]
    public string? WorkEmail { get; set; }

}