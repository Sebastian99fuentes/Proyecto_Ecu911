﻿using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Ecu911.Servicios
{
    //public class DateTime?JsonConverter : JsonConverter<DateTime?>
    //{

    //    private const string Format = "yyyy-MM-dd";

    //    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        return DateTime?.ParseExact(reader.GetString()!, Format, CultureInfo.InvariantCulture);
    //    }

    //    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    //    {
    //        writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
    //    }
    //}
}
