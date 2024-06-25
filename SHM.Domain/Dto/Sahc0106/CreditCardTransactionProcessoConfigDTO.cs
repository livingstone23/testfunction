namespace SHM.Domain.Dto.Sahc0106;

public class CreditCardTransactionProcessoConfigDTO
{

    public Guid CreditCardTransactionProcessoConfigKey { get; set; }
    public string TemplateSendMail { get; set; }
    public string EmailToConfirmTransaction { get; set; }
    public bool Active { get; set; }
    public DateTime? Created { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public Guid? ModifiedBy { get; set; }


}