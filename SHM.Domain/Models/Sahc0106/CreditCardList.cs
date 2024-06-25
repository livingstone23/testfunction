using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SHM.Domain.Models.Sahc0100;


namespace SHM.Domain.Models.Sahc0106;



[Table("CreditCardList", Schema = "Sahc0106")]
public class CreditCardList
{


    [Key]
    public Guid CreditCardListKey { get; set; }

    [ForeignKeyAttribute("CreditCardMasterGeneral")]
    public Guid CreditCardMasterGeneralKey { get; set; }
    public CreditCardMasterGeneral CreditCardMasterGeneral { get; set; }


    [ForeignKeyAttribute("EntityMasterGeneral")]
    public Guid EntityMasterGeneralKey { get; set; }
    public EntityMasterGeneral EntityMasterGeneral { get; set; }

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