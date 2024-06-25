using Newtonsoft.Json;
using System.Globalization;



namespace SHM.Domain.Helper;



public class CustomDateTimeConverter : Newtonsoft.Json.Converters.DateTimeConverterBase
{
    private CultureInfo ci = new CultureInfo("es-ES");

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var date = DateTime.ParseExact((string)reader.Value, "dd/MM/yyyy", ci);
        return date;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        writer.WriteValue(((DateTime)value).ToString("dd/MM/yyyy"));
    }
}

public class CustomTimeSpanConverter : Newtonsoft.Json.JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(TimeSpan);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        return TimeSpan.Parse((string)reader.Value);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        writer.WriteValue(((TimeSpan)value).ToString());
    }
}

