using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common.Argument
{
    public partial struct ArgElement
    {
        public ArgClass ArgClass;
        public string String;

        public static implicit operator ArgElement(ArgClass ArgClass) => new ArgElement { ArgClass = ArgClass };
        public static implicit operator ArgElement(string String) => new ArgElement { String = String };
    }

    public partial class ArgClass
    {
        [JsonProperty("cl_type")]
        public string cl_type { get; set; }

        [JsonProperty("bytes")]
        public string bytes { get; set; }

        [JsonProperty("parsed")]
        public string parsed { get; set; }
    } 
      

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ArgElementConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ArgElementConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ArgElement) || t == typeof(ArgElement?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new ArgElement { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<ArgClass>(reader);
                    return new ArgElement { ArgClass = objectValue };
            }
            throw new JsonReaderException("Cannot unmarshal type ArgElement");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (ArgElement)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.ArgClass != null)
            {
                serializer.Serialize(writer, value.ArgClass);
                return;
            }
            throw new JsonWriterException("Cannot marshal type ArgElement");
        }

        public static readonly ArgElementConverter Singleton = new ArgElementConverter();
    }
}
