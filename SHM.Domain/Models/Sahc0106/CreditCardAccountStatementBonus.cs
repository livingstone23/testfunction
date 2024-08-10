using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SHM.Domain.Models.Sahc0106;



[Table("CreditCardAccountStatementBonus", Schema = "Sahc0106")]
public class CreditCardAccountStatementBonus
{
    [Key]
    public Guid CreditCardAccountStatementBonusKey { get; set; }
    public Guid CreditCardAccountStatementKey { get; set; }

    public int Type { get; set; }

    public string Description { get; set; }
    public decimal Amount { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }


}

