using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Dto.Sahc0106;



public class CreditCardListDTO
{


    public Guid CreditCardListKey { get; set; }

    public Guid CreditCardMasterGeneralKey { get; set; }

    public Guid EntityMasterGeneralKey { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string CardName { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string CardNumber { get; set; }

    public DateTime CreationDate { get; set; }

    public char Status { get; set; }
    public short? CheckDigit { get; set; }
    public short? ExpirationMonth { get; set; }
    public short? ExpirationYear { get; set; }
    public DateTime? ActivationDate { get; set; }
    public DateTime? CutDay { get; set; }
    public bool Main { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? MainCardKey { get; set; }
    public int? Sequential { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? CodExterno { get; set; }





    /// <summary>
    /// Campos agregados en 2024/Abril 
    /// </summary>
    [Column(TypeName = "NVARCHAR(250)")]
    public string? StatusMessage { get; set; }

    public Guid? CreditCardStatusKey { get; set; }




    
    public DateTime? Created { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public Guid? ModifiedBy { get; set; }


}

