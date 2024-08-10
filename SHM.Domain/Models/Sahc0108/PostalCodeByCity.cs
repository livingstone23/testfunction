using SHM.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Models.Sahc0108;



[Table("PostalCodeByCity", Schema = "")]
public class PostalCodeByCity : BaseDomainModel
{

    [Key]
    public Guid PostalCodeByCityKey { get; set; }

    [ForeignKey("City")]
    public Guid CityKey { get; set; }

    public int PostalCode { get; set; }

    public Township City { get; set; }

}


