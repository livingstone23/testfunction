using SHM.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;



namespace SHM.Domain.Models.Sahc0106;



[Table("CreditRequestWorkingInformation", Schema = "Sahc0106")]
public class CreditRequestWorkingInformation : BaseDomainModel
{


    [Key]
    public Guid CreditRequestWorkingInformationKey { get; set; }


    [ForeignKey("CreditRequestMasterDetails")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CreditRequestMasterDetailKey { get; set; }
    [JsonIgnore]
    public CreditRequestMasterDetail CreditRequestMasterDetails { get; set; }


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
