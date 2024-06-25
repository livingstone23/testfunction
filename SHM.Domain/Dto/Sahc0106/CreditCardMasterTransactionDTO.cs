using Microsoft.Kiota.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Dto.Sahc0106;


/// <summary>
/// Envida envida en el payload para procesar movimiento.
/// </summary>
public class CreditCardMasterTransactionDTO
{
    /// <summary>
    /// Id del Catalogo del store
    /// </summary>
    public Guid? StoreKey { get; set; }
    public string Store { get; set; }
    public string PosId { get; set; }
    public string User { get; set; }

    public Guid? UserKey { get; set; }

    public Guid? CashierKey { get; set; }

    public string TransactionNumber { get; set; }

    public DateTime? DateTime { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public string Type { get; set; }
    public string CardNumber { get; set; }
    public decimal Amount { get; set; }

    public string? StoreName { get; set; } = string.Empty;

    public string? TransactionDescription { get; set; } = string.Empty;

    public string? EmailToSend { get; set; } = string.Empty;

    public string? FullName { get; set; } = string.Empty;

    public string? Email { get; set; } = string.Empty;

    public string? Phone { get; set; } = string.Empty;

    public string? Mobile { get; set; } = string.Empty;

    public string? RefId { get; set; } = string.Empty;

    public string? CodCliente { get; set; } = string.Empty;


    public Guid? CatalogKey { get; set; }

    public string? ReasonDescription { get; set; } = string.Empty;
    public string? Comment { get; set; } = string.Empty;


    /// <summary>
    /// Guid del tipo de transaccion.
    /// </summary>
    public Guid? TransactionTypeKey { get; set; }

    /// <summary>
    /// String del tipo de transaccion.
    /// En el caso de ivend es un valor por defecto.
    /// </summary>
    [Column(TypeName = "NVARCHAR(50)")]
    public string ExecutingSystem { get; set; }

    /// <summary>
    /// Es una enumeracion opcional, es el que genera IVEND
    /// </summary>
    [Column(TypeName = "NVARCHAR(50)")]
    public string? ExecutingSystemTransactionId { get; set; } = string.Empty;

    /// <summary>
    /// String Opcional libre, de tipo GuidD de la transacción
    /// </summary>
    [Column(TypeName = "NVARCHAR(50)")]
    public string? ExecutingSystemTransactionKey { get; set; } 







}

