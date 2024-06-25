using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions;


namespace SHM.Domain.Dto.Sahc0106;



public class CreditCardTransactionProcessorDetailDTO
{


    public Guid CreditCardTransactionProcessorDetailKey { get; set; }

    public Guid CreditCardTransactionProcessorKey { get; set; }

    //Datos del movimiento
    [Column(TypeName = "NVARCHAR(10)")]
    public string TypeMovement { get; set; }
    [Column(TypeName = "decimal(18, 4)")]
    public Decimal Value { get; set; }
    [Column(TypeName = "decimal(18, 4)")]
    public decimal Balance { get; set; }
    [Column(TypeName = "NVARCHAR(50)")]
    public string StoreId { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string PostId { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string UserId { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string CardNumber { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string CodCliente { get; set; }

    [Column(TypeName = "NVARCHAR(100)")]
    public string Message { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string ApprovalNumber { get; set; }
    [Column(TypeName = "NVARCHAR(50)")]
    public string TransactionNumber { get; set; }

    public string? EmailMessageId { get; set; }


    public bool IsRevert { get; set; }
    public Date DateField { get; set; }
    public Time TimeField { get; set; }


    public Guid? CatalogGenericKey { get; set; }

    [Column(TypeName = "NVARCHAR(250)")]
    public string? ReasonDescription { get; set; }

    [Column(TypeName = "NVARCHAR(250)")]
    public string? Comment { get; set; }





    //Nuevos campos
    public Guid? BranchMasterGeneralKey { get; set; }
    public Guid? CreditCardTransactionTypeKey { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? CodExterno { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? ExecutingSystem { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? ExecutingSystemTransactionId { get; set; }
    [Column(TypeName = "NVARCHAR(50)")]
    public string? ExecutingSystemTransactionKey { get; set; }

    public DateTime? TransactionDate { get; set; }

    public int? DocEntry { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? Terminal { get; set; }

    public Guid? ExecutingSystemGeneralKey { get; set; }





    //Campos de control.
    public DateTime? Created { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public Guid? ModifiedBy { get; set; }


}

