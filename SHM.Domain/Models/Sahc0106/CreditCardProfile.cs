using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Models.Sahc0106;



[Table("CreditCardProfile", Schema = "Sahc0106")]
public class CreditCardProfile
{


    [Key]
    public Guid CreditCardProfileKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "NVARCHAR(100)")]
    public string ProfileName { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public decimal InterestRate { get; set; }

    
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public short CutDay { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public DateTime CreatedDate { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "NCHAR(1)")]
    public string AnnuityType { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "decimal(18, 4)")]
    public decimal AnnuityValue { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "NVARCHAR(10)")]
    public string LiveInsureType { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "decimal(18, 4)")]
    public decimal LiveInsureValue { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "NVARCHAR(10)")]
    public string FraudInsuranceType { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "decimal(18, 4)")]
    public decimal FraudInsuranceValue { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "NVARCHAR(10)")]
    public string LateFeeType { get; set; }

    public Guid? LateFeeCode { get; set; }

    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "decimal(18, 4)")]
    public decimal LateFeeValue { get; set; }





    /// <summary>
    /// Campos nuevos agregados
    /// </summary>
    [Column(TypeName = "CHAR(10)")]
    public string? InterestRateType { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? InterestRateValue { get; set; }

    public bool? HasLoyalty { get; set; }

    public bool? HasCashBack { get; set; }





    //Campos de control
    public DateTime? Created { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public Guid? ModifiedBy { get; set; }

    
}