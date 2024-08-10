using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHM.Domain.Models.Sahc0106;


namespace SHM.Domain.Dto.Sahc0106;

public class ResumeCreditBalanceDTO
{

    public CreditCardBalanceDTO CreditCardBalance { get; set; }

    public CreditCardAccountStatementDTO CreditCardAccountStatment { get; set; }

}

