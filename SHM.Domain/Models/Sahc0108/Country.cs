using SHM.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Models.Sahc0108;



[Table("Country", Schema = "Sahc0108")]
public class Country : BaseDomainModel
{

    [Key]
    public Guid CountryKey { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string? Name { get; set; }
    

    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string? Nationality { get; set; }
    

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

    //public IEnumerable<Province> Provinces { get; set; }

    //public IEnumerable<OnBoarding> OnBoardingImsas { get; set; }

    //public IEnumerable<OnBoardingMaritalInformation> EntityMaritalInformations { get; set; }

    //public IEnumerable<OnBoardingAdditionalCard> EntityAdditionalCards { get; set; }




}


