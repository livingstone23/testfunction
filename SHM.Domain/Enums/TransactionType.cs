using System.Reflection;



namespace SHM.Domain.Enums;



public enum TransactionType
{
    [EnumStringValue("02")]
    Compra = 2,
    [EnumStringValue("07")]
    ReversionCompra = 7,
    [EnumStringValue("87")]
    ReversionPago = 87,
    [EnumStringValue("52")]
    PagoCuenta = 52
}

public enum StatusCard
{
    [EnumStringValue("1")]
    Activa = 1,
    [EnumStringValue("2")]
    Perdido = 2,
    [EnumStringValue("3")]
    Retenido = 3,
    [EnumStringValue("4")]
    En_Recuperacion = 4,
    [EnumStringValue("5")]
    Cuenta_Cerrada = 5,
    [EnumStringValue("6")]
    Destruido = 6,
    [EnumStringValue("7")]
    Deteriorado = 7,
    [EnumStringValue("-1")]
    Indefinido = -1
}


[AttributeUsage(AttributeTargets.Field)]
public class EnumStringValueAttribute : Attribute
{
    public string Value { get; private set; }

    public EnumStringValueAttribute(string value)
    {
        Value = value;
    }
}


public static class EnumExtensions
{
    public static string GetStringValue(this Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        EnumStringValueAttribute[] attributes =
            (EnumStringValueAttribute[])fi.GetCustomAttributes(typeof(EnumStringValueAttribute), false);

        if (attributes.Length > 0)
        {
            return attributes[0].Value;
        }

        return value.ToString();
    }

    public static T ParseEnum<T>(string value)
    {
        foreach (var field in typeof(T).GetFields())
        {
            var attribute = Attribute.GetCustomAttribute(field,
                typeof(EnumStringValueAttribute)) as EnumStringValueAttribute;
            if (attribute != null)
            {
                if (attribute.Value == value)
                    return (T)field.GetValue(null);
            }
            else
            {
                if (field.Name == value)
                    return (T)field.GetValue(null);
            }
        }

        throw new ArgumentException("Not found.", "value");
        // or return default(T);
    }
}