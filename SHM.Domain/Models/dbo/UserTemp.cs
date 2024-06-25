using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SHM.Domain.Models.dbo;



[Table("UserTemp", Schema = "dbo")]
public class UserTemp
{
    [Key]
    public Guid UserTempKey { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string UserName { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Password { get; set; }

}

