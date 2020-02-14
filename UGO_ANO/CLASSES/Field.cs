using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace UGO_ANO.CLASSES
{
    public class Field
    {
        public string Table { get; set; }
        public string Column { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Type Type { get; set; }

        [JsonProperty(JsonPropertyAttribute.)]
        public int Option { get; set; }
    }

    public enum Type
    {
        [EnumMember(Value = "TINT")]
        TINT,
        [EnumMember(Value = "TBOLO")]
        TBOLO,
        [EnumMember(Value = "TDATE")]
        TDATE
    };
}
