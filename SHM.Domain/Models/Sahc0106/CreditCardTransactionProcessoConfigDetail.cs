using System.ComponentModel.DataAnnotations;

namespace SHM.Domain.Models.Sahc0106;

public class CreditCardTransactionProcessoConfigDetail
{

    [Key]
    public Guid CreditCardTransactionProcessoConfigDetailKey { get; set; }
    public Guid CreditCardTransactionProcessoConfigKey { get; set; }
    public string TemplateUsed { get; set; }
    public string TransactionSend { get; set; }
    public DateTime? Created { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public Guid? ModifiedBy { get; set; }


}