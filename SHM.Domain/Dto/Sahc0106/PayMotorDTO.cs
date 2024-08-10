using SHM.Domain.Dto.dbo;
using SHM.Domain.Models.Sahc0104;
using SHM.Domain.Models.Sahc0106;



namespace SHM.Domain.Dto.Sahc0106;



public class PayMotorDTO 
{


    /// <summary>
    /// Numero de operacion propuesto.
    /// </summary>
    public string? numOperationStr { get; set; }


    public string? transactionDescription { get; set; }


    /// <summary>
    /// Tabla para identificar la sucursal.
    /// </summary>
    public BranchMasterGeneral branchMasterGeneral { get; set; }

    /// <summary>
    /// Tabla para identificar los ciclos.
    /// </summary>
    public BillingCycleMaster CycleMaster { get; set; }

    /// <summary>
    /// Permite identificar el tipo de transaccion que se esta procesando
    /// </summary>
    public CreditCardTransactionsType transactionsType { get; set; }



    /// <summary>
    /// Permite registrar cual es la transaccion de compra.
    /// </summary>
    public CreditCardTransactionsType TransactionBuy { get; set; }


    /// <summary>
    /// Permite registrar cual es la transaccion de pago.
    /// </summary>
    public CreditCardTransactionsType TransactionPay { get; set; }

    /// <summary>
    /// Documento que registra el movimiento que se esta procesando
    /// </summary>
    public CreditCardMasterTransactionDTO TranDto { get; set; }


    /// <summary>
    /// Entidades para el manejo de pago masivo, Maestro
    /// </summary>
    public BatchCollectionDTO BatchCollectionDTO { get; set; }





    /// <summary>
    /// Registro de la tarjeta de credito que se esta procesando
    /// </summary>
    public CreditCardList creditCardList { get; set; }


    /// <summary>
    /// Clase visual para presentar el Motor de credito.
    /// </summary>
    public CreditCardTransactionProcessorVisualDTO tranProcessorVisual { get; set; }

    /// <summary>
    /// Clase que maneja los saldos de cuenta del motor de pago
    /// </summary>
    public CreditCardTransactionProcessor  tranProcessor { get; set; }


    /// <summary>
    /// Clase para manejar los detalles del procesador de transaccion
    /// </summary>
    public CreditCardTransactionProcessorDetail tranProcessorDetail { get; set; }



    /// <summary>
    /// Clase para dejar log de como estaba el maestro de tarjeta de credito antes de procesar la transaccion
    /// </summary>
    public CreditCardTransactionProcessorLog tranProcessorLog { get; set; }


    /// <summary>
    /// Clase que permite manejar el ciclo de procesamiento de la tarjeta de credito hasta el final de periodo, permitira registrar
    /// hasta los pagos hacia atras en fechas posteriores al cierre de periodo, importante para crear el proceso de cierre de periodo
    /// </summary>
    public CreditCardTranProcessorCycle tranProcessorCycle { get; set; }


    /// <summary>
    /// Tabla historica que permitira dejar un log de los procesos de cierre de periodo de como quedo al ultimo dia del mes el motor de pago
    /// </summary>
    public CreditCardTranProcessorCycleLog tranProcessorCycleLog { get; set; }


    /// <summary>
    /// Propiedad que permite controlar si hubo un error en el proceso de motor de pago
    /// </summary>
    public string? ErrorMessage { get; set; } = string.Empty;

    public string? ErrorMessageUser { get; set; } = string.Empty;


    /// <summary>
    /// Propiedad que permite controlar si el registro fue cargado por pagos masivos
    /// </summary>
    public bool? IsByBatchProcess { get; set; } = false;

    /// <summary>
    /// Propiedad que permite transferir el valor de PayReference de pago masivo
    /// </summary>
    public string? PayReference { get; set; } = string.Empty;

    /// <summary>
    /// Propiedad que permite transferir el valor de RawDescription de pago masivo
    /// </summary>
    public string? RawDescription { get; set; } = string.Empty;

    /// <summary>
    /// Valor que permite unificar vs el registro de pago masivo
    /// </summary>
    public Guid? UniqueValue { get; set; }

}

