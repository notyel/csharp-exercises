using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class CustomDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Lee el valor de la cadena del lector JSON
        string dateStr = reader.GetString();

        // Convierte la cadena al formato de fecha deseado
        if (DateTime.TryParseExact(dateStr, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime date))
        {
            return date;
        }

        // Si no se puede analizar la fecha, puedes devolver un valor predeterminado o lanzar una excepción según tus necesidades
        return DateTime.MinValue;
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        // Escribe la fecha en el formato deseado al serializarla
        writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
    }
}
