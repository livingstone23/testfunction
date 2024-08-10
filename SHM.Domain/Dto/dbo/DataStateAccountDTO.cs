using SHM.Domain.Models.Sahc0100;
using SHM.Domain.Models.Sahc0106;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Domain.Dto.dbo;

public class DataStateAccount
{

    public EntityMasterGeneral EntityMasterGeneral { get; set; }
    public EntityMasterGroup EntityMasterGroup { get; set; }
    public EntityMasterExternalReference EntityMasterExternalReference { get; set; }
    public CreditCardAccountStatement CreditCardAccountStatement { get; set; }
    public List<CreditCardAccountStatementDetail> CreditCardAccountStatementDetails { get; set; } = new List<CreditCardAccountStatementDetail>();
    public List<CreditCardAccountStatementBonus> CreditCardAccountStatementBonus { get; set; } = new List<CreditCardAccountStatementBonus>();


}

