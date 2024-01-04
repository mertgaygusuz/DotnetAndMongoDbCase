using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DotnetMongoCase.Models.Contacts
{
    public class JsonDocumentConverter : JsonConverter<JsonDocument>
    {
        public override JsonDocument Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument document = JsonDocument.ParseValue(ref reader))
            {
                return JsonDocument.Parse(document.RootElement.ToString());
            }
        }

        public override void Write(Utf8JsonWriter writer, JsonDocument value, JsonSerializerOptions options)
        {
            value.WriteTo(writer);
        }
    }
}
