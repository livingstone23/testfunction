using SHM.Domain.Common;
using SHM.Domain.Models.Sahc0106;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SHM.Domain.Dto.Sahc0106;

public class CreditRequestWorkingInformationDTO : BaseDomainModel
{

    public Guid CreditRequestWorkingInformationKey { get; set; }


    
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CreditRequestMasterDetailKey { get; set; }



    [Column(TypeName = "NVARCHAR(100)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string CompanyName { get; set; }


    [Column(TypeName = "NVARCHAR(100)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Position { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public DateTime AdmissionDate { get; set; }


    [Column(TypeName = "DECIMAL(10,2)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public decimal Antiquity { get; set; }


    [Column(TypeName = "NVARCHAR(200)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string WorkAddress { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? OfficePhone { get; set; }


    [Column(TypeName = "DECIMAL(10,2)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public decimal MonthlyIncome { get; set; }


    [Column(TypeName = "DECIMAL(10,2)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public decimal BaseSalary { get; set; }


    [Column(TypeName = "DECIMAL(10,2)")]
    public decimal? OtherIncome { get; set; }


    [Column(TypeName = "NVARCHAR(200)")]
    public string Detail { get; set; }


    [EmailAddress]
    [Column(TypeName = "NVARCHAR(100)")]
    public string? WorkEmail { get; set; }

}