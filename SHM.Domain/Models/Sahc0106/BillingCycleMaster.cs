using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SHM.Domain.Models.Sahc0106;



[Table("BillingCycleMaster", Schema = "Sahc0106")]
public class BillingCycleMaster
{

    [Key]
    public Guid BillingCycleMasterKey { get; set; }
    [Column(TypeName = "NVARCHAR(50)")]
    public string Name { get; set; }
    [Column(TypeName = "NVARCHAR(250)")]
    public string Description { get; set; }
    public Guid BillingCycleStateKey { get; set; }
    public int YearCycle { get; set; }
    public int NumCycle { get; set; }
    public DateTime? ReportedAPC { get; set; }
    public DateTime? PaymentDueDate { get; set; }

    public bool InOperation { get; set; }
    [Column(TypeName = "NVARCHAR(10)")]
    public string NumOperation { get; set; }




    //Campos de control
    public DateTime? Created { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public Guid? ModifiedBy { get; set; }

}

