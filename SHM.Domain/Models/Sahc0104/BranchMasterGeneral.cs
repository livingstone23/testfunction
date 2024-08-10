using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHM.Domain.Models.Sahc0104;

[Table("BranchMasterGeneral", Schema = "Sahc0104")]
public class BranchMasterGeneral {

    [Key]
    public Guid BranchMasterGeneralKey { get; set; }

    public Guid? CompanyGeneralKey { get; set; }

    [Column(TypeName = "NVARCHAR(250)")]
    public string? Description { get; set; }


    [Column(TypeName = "NVARCHAR(250)")]
    public string? Detail { get; set; }


    public decimal? Longitude { get; set; }

    public decimal? Latitude { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? Email { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? CountryId { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string Code { get; set; }

    public Guid? AddressId { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? AddressFiscalCode { get; set; }

    public bool? DefaultBranchOffice { get; set; }


    //public bool Status { get; set; }

    //public byte[] TimeStamp { get; set; }

    //[Column(TypeName = "NVARCHAR(100)")]
    //public string? EmailFinanciera { get; set; }

    [Column(TypeName = "VARCHAR(30)")]
    public string? CostCenter { get; set; }

    public bool? IsActive { get; set; }

    [Column(TypeName = "VARCHAR(255)")]
    public string? EmailBranchOffice { get; set; }



    //Campos de control
    public DateTime? Created { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public Guid? ModifiedBy { get; set; }

}

