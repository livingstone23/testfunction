using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace SHM.Domain.Dto.Sahc0104;



public class DataImportDTO
{


    public Guid DataImportKey { get; set; }

    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public int DocNum { get; set; }

    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? DataTypeMasterKey { get; set; }

    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? UserMasterGeneralKey { get; set; }

    [Column(TypeName = "NVARCHAR(250)")]
    public string? Comments { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string? Path { get; set; }

    [Column(TypeName = "NVARCHAR(250)")]
    public string? Results { get; set; }



    //Campos de control
    public DateTime? Created { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public Guid? ModifiedBy { get; set; }


}