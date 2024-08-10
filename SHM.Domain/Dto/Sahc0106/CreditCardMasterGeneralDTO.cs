using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Dto.Sahc0106;



public class CreditCardMasterGeneralDTO 
{

    //[Key]
    public Guid CreditCardMasterGeneralKey { get; set; }


    //[Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? EntityMasterGeneralKey { get; set; }


    //[Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CreditCardProfileKey { get; set; }


    //[Required(ErrorMessage = "El {0} es un campo requerido. ")]
    //[Column(TypeName = "NVARCHAR(50)")]
    //public string CardName { get; set; }


    //[Required(ErrorMessage = "El {0} es un campo requerido. ")]
    //[Column(TypeName = "NVARCHAR(50)")]
    //public string CardNumber { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public DateTime CreationDate { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "NCHAR(1)")]
    public string Status { get; set; }

    public int? AccountNumber { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? CodExterno1 { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? CodExterno2 { get; set; }

    public bool? IsActive { get; set; }


    //public short? CheckDigit { get; set; }

    //public short? ExpirationMonth { get; set; }

    //public short? ExpirationYear { get; set; }

    //public DateTime? ActivationDate { get; set; }

    //public decimal? Amount { get; set; }

    //public DateTime? CutDay { get; set; }


    //[Required(ErrorMessage = "El {0} es un campo requerido. ")]
    //public bool Main { get; set; }



    //public Guid? MainCardKey { get; set; }


    //public int? Sequential { get; set; }


    //[Column(TypeName = "NVARCHAR(50)")]
    //public string? CodExterno { get; set; }




    
    /// <summary>
    /// Campos agregados en 2024/Abril 
    /// </summary>
    [Column(TypeName = "NVARCHAR(50)")]
    public string? LoyaltyCardNumber { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? LoyaltyCardKey { get; set; }

    public Guid? CreditCardMasterStatusKey { get; set; }

    [Column(TypeName = "NVARCHAR(250)")]
    public string? StatusMessage { get; set; }

    public bool? HasLoyalty { get; set; }

    public bool? HasCashBack { get; set; }




    
    public virtual ICollection<CreditCardBalanceDTO> CreditCardBalancesDTO { get; set; } = new List<CreditCardBalanceDTO>();



    //Campos de control
    public DateTime? Created { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public Guid? ModifiedBy { get; set; }


}

