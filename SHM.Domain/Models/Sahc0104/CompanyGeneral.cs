using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SHM.Domain.Models.Sahc0104;



[Table("CompanyGeneral", Schema = "Sahc0104")]
public class CompanyGeneral
{

    [Key]
    public Guid  CompanyGeneralKey { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? Code { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? Name { get; set; }

    [Column(TypeName = "NVARCHAR(150)")]
    public string? FullName { get; set; }

    public bool DefaultCompany { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? NumberId { get; set; }

    [Column(TypeName = "NVARCHAR(650)")]
    public string? ProfileImage { get; set; }

    [Column(TypeName = "NVARCHAR(450)")]
    public string? Address { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? Phone { get; set; }

    public bool Status { get; set; }

    public byte[] TimeStamp { get; set; }

    [Column(TypeName = "NVARCHAR(10)")]
    public string? DV { get; set; }

    public bool ActiveEInvoice { get; set; }

    public Guid? AddressId { get; set; }

    [Column(TypeName = "NVARCHAR(10)")]
    public string? PhoneCountryCode { get; set; }

    public int? TypeTaxpayer { get; set; }



    //Campos de control
    public DateTime? Created { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public Guid? ModifiedBy { get; set; }

}

