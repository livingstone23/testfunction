using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SHM.Domain.Models.Sahc0106;



[Table("CatalogGeneric", Schema = "Sahc0106")]
public class CreditCardTransactionProcessoConfig
{

    [Key]
    public Guid CreditCardTransactionProcessoConfigKey { get; set; }
    public string TemplateSendMail { get; set; }
    public string EmailToConfirmTransaction { get; set; }
    public bool Active { get; set; }
    public DateTime? Created { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public Guid? ModifiedBy { get; set; }

}

