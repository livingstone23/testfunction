using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Dto.Sahc0106;



public class CreditCardTransactionsTypeDTO
{


    public Guid CreditCardTransactionsTypeKey { get; set; }

    /// <summary>
    /// Campo para una descripción de la transaccion.
    /// </summary>
    [Column(TypeName = "NVARCHAR(50)")]
    public string? Description { get; set; }

    /// <summary>
    /// Campo para indicar el status de la transacción.
    /// </summary>
    public bool? Status { get; set; }

    /// <summary>
    /// Campo para registar el código del tipo de transacción.
    /// </summary>
    [Column(TypeName = "NVARCHAR(50)")]
    public string? Code { get; set; }

    /// <summary>
    /// Campo para registrar una breve descripcion del tipo de transaccion.
    /// </summary>
    [Column(TypeName = "NVARCHAR(250)")]
    public string? Details { get; set; }

    /// <summary>
    /// Campo que indica si el tipo de transaccion esta relacionado a una cuenta contable
    /// </summary>
    [Column(TypeName = "NVARCHAR(50)")]
    public string? FinantialAccount { get; set; }

    /// <summary>
    /// Campo para registrar el tipo de ajuste, si es de tipo
    /// Debit o Credit
    /// </summary>
    [Column(TypeName = "CHAR(10)")]
    public string? AdjusmentType { get; set; }

    /// <summary>
    /// Permite indicar un código externo.
    /// </summary>
    [Column(TypeName = "NVARCHAR(50)")]
    public string? ExternalCode1 { get; set; }

    /// <summary>
    /// Permite indicar un segundo código externo.
    /// </summary>
    [Column(TypeName = "NVARCHAR(50)")]
    public string? ExternalCode2 { get; set; }

    /// <summary>
    /// El campo indica si es un tipo de transacción del sistema.
    /// </summary>
    public bool? IsSystem { get; set; }


    //Campos de control.
    public DateTime? Created { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public Guid? ModifiedBy { get; set; }

}