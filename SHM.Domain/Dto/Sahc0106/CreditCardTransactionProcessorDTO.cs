using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SHM.Domain.Dto.Sahc0106;



public  class CreditCardTransactionProcessorDTO
{


    public Guid CreditCardTransactionProcessorKey { get; set; }

    public Guid CreditCardMasterGeneralKey { get; set; }

    public Guid CreditCardBalanceKey { get; set; }


    //Datos de compras
    public DateTime? LastPayDate { get; set; }
    public string? LastPayNumber { get; set; }
    //Datos de pagos
    public DateTime? LastBillDate { get; set; }
    public string? LastBillNumber { get; set; }
    

    public decimal CreditLimit { get; set; }
    public decimal Available { get; set; }
    public decimal Balance { get; set; }

    public decimal MinimunPayment { get; set; }


    public DateTime? Created { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public Guid? ModifiedBy { get; set; }

}

