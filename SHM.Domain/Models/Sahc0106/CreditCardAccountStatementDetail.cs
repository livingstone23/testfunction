using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SHM.Domain.Models.Sahc0106;



[Table("CreditCardAccountStatementDetail", Schema = "Sahc0106")]
public class CreditCardAccountStatementDetail
{

    [Key]
    public Guid CreditCardAccountStatementDetailKey { get; set; }
    public Guid CreditCardAccountStatementKey { get; set; }
    public int Num { get; set; }
    public DateTime Date { get; set; }
    public string CodeTrans { get; set; }
    public string Description { get; set; }
    public decimal Credit { get; set; }
    public decimal Debit { get; set; }
    public decimal Balance { get; set; }

}


