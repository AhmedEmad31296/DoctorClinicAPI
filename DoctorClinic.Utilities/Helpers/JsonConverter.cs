﻿//using System.Text.Json.Serialization;
//using System.Text.Json;
//using System.Threading.Tasks;

namespace DoctorClinic.Utilities.Helpers
{
    //public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    //{
    //    private const string Format = "yyyy-MM-dd";

    //    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        return DateOnly.ParseExact(reader.GetString(), Format, CultureInfo.InvariantCulture);
    //    }

    //    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    //    {
    //        writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
    //    }
    //}
    //public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
    //{
    //    private const string Format = "HH:mm:ss.fff";

    //    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        return TimeOnly.ParseExact(reader.GetString(), Format, CultureInfo.InvariantCulture);
    //    }

    //    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
    //    {
    //        writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
    //    }
    //}

    //    public class TimeOnlyConverter : JsonConverter<TimeOnly>
    //{
    //    private readonly string serializationFormat;

    //    public TimeOnlyConverter() : this(null)
    //    {
    //    }

    //    public TimeOnlyConverter(string? serializationFormat)
    //    {
    //        this.serializationFormat = serializationFormat ?? "HH:mm:ss.fff";
    //    }

    //    public override TimeOnly Read(ref Utf8JsonReader reader,
    //                            Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        var value = reader.GetString();
    //        return TimeOnly.Parse(value!);
    //    }

    //    public override void Write(Utf8JsonWriter writer, TimeOnly value,
    //                                        JsonSerializerOptions options)
    //        => writer.WriteStringValue(value.ToString(serializationFormat));
}

