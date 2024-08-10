namespace SHM.Domain.Dto;

public class ResponseDto
{
    public object? Result { get; set; }
    public bool IsSuccess { get; set; } = true;
    public string Message { get; set; } = "";
}

public class ResponseMotorDto
{
    public string Result { get; set; } = "OK";
    public List<object?>? Data { get; set; }
}

public class ResponseCreditCardDto
{
    public string Error { get; set; } = "NO";
    public string Message { get; set; } = "OK";
    public string AuthCode { get; set; } = "";
    public int? Count { get; set; }

}


public class ResponsePagDto
{
    public object? Result { get; set; }
    public bool IsSuccess { get; set; } = true;
    public string Message { get; set; } = "";

    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public int TotalRegister { get; set; }

    public int TotalPages { get; set; }

}

public class DataItem
{
    public string? CodCliente { get; set; }
    public string? CardNumber { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Cedula { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public string? Type { get; set; }
    public string? Status { get; set; }
    public string? DigitalCard { get; set; }
    public decimal? CreditLimit { get; set; }
    public decimal? Balance { get; set; }
    public decimal? Available { get; set; }

    public decimal? Current { get; set; }
    public decimal? Balance30 { get; set; }
    public decimal? Balance60 { get; set; }
    public decimal? Balance90 { get; set; }
    public decimal? Balance120 { get; set; }
    public decimal? PayMin { get; set; }
    public int? AccountNumber { get; set; }
    public string? LoyaltyCardNumber { get; set; }

    public string? StatusAccount { get; set; }
    public string? StatusCard { get; set; }

}
