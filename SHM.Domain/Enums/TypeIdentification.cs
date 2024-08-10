using System.Runtime.Serialization;

namespace SHM.Domain.Enums;

/// <summary>
/// Tipo de Identificacion
/// </summary>
public enum TypeIdentification
{
    
    [EnumMember(Value = "Cedula")]
    Cedula,

    [EnumMember(Value = "Pasaporte")]
    Pasaporte,

    [EnumMember(Value = "Ruc")]
    RUC,

    [EnumMember(Value = "Otro")]
    Otro,

}


/// <summary>
/// Genero
/// </summary>
public enum Gender
{

    [EnumMember(Value = "Masculino")]
    Masculino,

    [EnumMember(Value = "Femenino")]
    Femenino,

    [EnumMember(Value = "No definir")]
    NoDefinir

}

public enum ActionData
{
    [EnumMember(Value = "Agregar")]
    Add,
    [EnumMember(Value = "Actualizar")]
    Update,
    [EnumMember(Value = "Eliminar")]
    Delete,
    [EnumMember(Value = "Editar")]
    Edit
}

public enum Method
{
    [EnumMember(Value = "Get")]
    Get,
    [EnumMember(Value = "Set")]
    Set,
    [EnumMember(Value = "Post")]
    Post,
    [EnumMember(Value = "Put")]
    Put,
    [EnumMember(Value = "Delete")]
    Delete,
}
