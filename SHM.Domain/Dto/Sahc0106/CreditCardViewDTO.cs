namespace SHM.Domain.Dto.Sahc0106;

public class CreditCardViewDTO {
    public Guid CreditCardListKey { get; set; }
    public Guid CreditCardMasterGeneralKey { get; set; }
    public Guid CreditCardProfileKey { get; set; }
    public string? ProfileName { get; set; }
    public Guid EntityMasterGeneralKey { get; set; }
    public Guid EntityMasterCardKey { get; set; }
    public string? CardName { get; set; }
    public string CardNumber { get; set; }
    public string CardStatusDesc { get; set; }
    public string? Status { get; set; }
    public int? ExpirationMonth { get; set; }
    public int? ExpirationYear { get; set; }
    public decimal CreditLimit { get; set; }
    public decimal Available { get; set; }
    public int? CutDay { get; set; }
    public bool? Main { get; set; }
    public Guid? MainCardKey { get; set; }
    public string CardType { get; set; }
    public string? MasterStatus { get; set; }
    public string? MasterStatusDesc { get; set; }

}
