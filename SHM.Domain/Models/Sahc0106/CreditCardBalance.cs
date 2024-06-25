using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Models.Sahc0106;


[Table("CreditCardBalance", Schema = "Sahc0106")]
public class CreditCardBalance 
{


    [Key]
    public Guid CreditCardBalanceKey { get; set; }

    
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CreditCardMasterGeneralKey { get; set; }
    [ForeignKey("CreditCardMasterGeneralKey")]
    public CreditCardMasterGeneral CreditCardMasterGeneral { get; set; }

    public decimal? CreditLimit { get; set; }

    public decimal? Available { get; set; }

    public decimal? OpeningBalance { get; set; }

    public decimal? Current { get; set; }

    public decimal? AmountDue { get; set; }


    //Manejo de compras
    public decimal? Balance { get; set; }

    public decimal? Balance30 { get; set; }

    public decimal? Balance60 { get; set; }

    public decimal? Balance90 { get; set; }

    public decimal? Balance120 { get; set; }


    //Manejo de Cargos
    public decimal? Cargo { get; set; }

    public decimal? Cargo30 { get; set; }

    public decimal? Cargo60 { get; set; }

    public decimal? Cargo90 { get; set; }

    public decimal? Cargo120 { get; set; }



    public decimal? MinimunPayment { get; set; }

    public int? PreviousPoints { get; set; }

    public int? NewPoints { get; set; }

    public int? TotalPoints { get; set; }

    public string Message { get; set; }


    public DateTime? Created { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public Guid? ModifiedBy { get; set; }


}

