using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Common;



/// <summary>
/// Clase base para plicar los campos de control
/// </summary>
public abstract class BaseDomainModel
{

    public bool Active { get; set; }

    public DateTime? Created { get; set; }


    public Guid? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }


    public Guid? ModifiedBy { get; set; }

}

