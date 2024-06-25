namespace SHM.Domain.Dto.Sahc0106;



public class CreditCardAccountStatementDTO
{
    public Guid CreditCardAccountStatementKey { get; set; }


    //[ForeignKey("CreditCardMasterGenerals")]
    public Guid? CreditCardMasterGeneralKey { get; set; }

    //[JsonIgnore]
    //public CreditCardMasterGeneral CreditCardMasterGenerals { get; set; }

    public DateTime? CreateDate { get; set; }
    public string? Year { get; set; }
    public string? Month { get; set; }
    public DateTime? CutDay { get; set; }
    public DateTime? DueDate { get; set; }
    public decimal? CreditLimit { get; set; }
    public decimal? Available { get; set; }
    public decimal? OpeningBalance { get; set; }
    public decimal? Current { get; set; }
    public decimal? Balance30 { get; set; }
    public decimal? Balance60 { get; set; }
    public decimal? Balance90 { get; set; }
    public decimal? Balance120 { get; set; }
    public decimal? Balance { get; set; }
    public decimal? AmountDue { get; set; }
    public decimal? MinimunPayment { get; set; }
    public decimal? PreviousPoints { get; set; }
    public decimal? NewPoints { get; set; }
    public decimal? TotalPoints { get; set; }
    public string? Message { get; set; }
    public string? Path { get; set; }
    public bool? PDFGenerated { get; set; }
    public bool? EmailSend { get; set; }
    public string? EmailId { get; set; }
    public int? EmailOpen { get; set; }
    public bool? EmailSpam { get; set; }

    public string? EmailMessageId { get; set; }

    public bool? EmailUnsubscribed { get; set; }

    public bool? EmailLinkClicked { get; set; }


    public string? AditionalCode { get; set; }

    public decimal? PointsDivA { get; set; }

    public decimal? PointsDivB { get; set; }

    public bool? EmailBounce { get; set; }

    public bool? EmailDropped { get; set; }

    public bool? SendMail { get; set; }

    public int? LineNumber { get; set; }
}

