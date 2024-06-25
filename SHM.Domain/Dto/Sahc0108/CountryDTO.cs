using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SHM.Domain.Common;



namespace SHM.Domain.Dto.Sahc0108;



public class CountryDTO : BaseDomainModel
{


    [Key]
    public Guid CountryKey { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Name { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Nationality { get; set; }

    [Column(TypeName = "NVARCHAR(20)")]
    public string? Abbreviation { get; set; }

    [Column("Country", TypeName = "NVARCHAR(50)")]
    public string? CountryC { get; set; }


    [Column(TypeName = "NVARCHAR(2)")]
    public string? Code { get; set; }

    public byte? DialValidMobile { get; set; }

    public byte? DialValidLine { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? Dial { get; set; }

    [Column(TypeName = "decimal(18,8)")]
    public decimal? Latitude { get; set; }

    [Column(TypeName = "decimal(18,8)")]
    public decimal? Longitude { get; set; }

    [Column(TypeName = "Text")]
    public string? Image { get; set; }

    public Guid? LanguageCodeKey { get; set; }

}