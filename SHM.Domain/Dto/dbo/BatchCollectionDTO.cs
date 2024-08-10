using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SHM.Domain.Dto.dbo;



/// <summary>
/// Is the Master class in the Batch Payment
/// </summary>
public class BatchCollectionDTO
{

    public string TransactionType { get; set; }

    public string DocUrl { get; set; }

    public List<BatchCollectionDetailDTO> data { get; set; } = new List<BatchCollectionDetailDTO>();

}



/// <summary>
/// Detail class thas is the detail of the Batch Payment
/// </summary>
public class BatchCollectionDetailDTO
{
    
    

    public DateTime? Date { get; set; }

    public string? Reference { get; set; }

    public String? PayReference { get; set; }

    public string? RawDescription { get; set; }

    public string? ErrorMessage { get; set; }

    public bool? IsLoaded { get; set; }

    public bool? IsVerified { get; set; }

    public bool? IsApplied { get; set; }

    public string? AuthCode { get; set; }

    public decimal Amount { get; set; }

    //Valor que permite uniformar el valor vs Motor de pago
    public Guid? UniqueValue { get; set; } 

    public string? CardName { get; set; }

}


