using System.ComponentModel.DataAnnotations.Schema;

namespace SHM.Domain.Dto.Sahc0106;



public class CreditCardProfileDTO
{

    public Guid CreditCardProfileKey { get; set; }



    public string ProfileName { get; set; }



    public decimal InterestRate { get; set; }



    public short CutDay { get; set; }



    public DateTime CreatedDate { get; set; }



    public string AnnuityType { get; set; }



    public decimal AnnuityValue { get; set; }



    public string LiveInsureType { get; set; }



    public decimal LiveInsureValue { get; set; }


    public string FraudInsuranceType { get; set; }



    public decimal FraudInsuranceValue { get; set; }



    public string LateFeeType { get; set; }

    public Guid? LateFeeCode { get; set; }

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

