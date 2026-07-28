using RestWithASPNET10.JsonSerializers;
using System.Text.Json.Serialization;

namespace RestWithASPNET10.Data.DTO.V2
{
    public class PersonDTO
    {
        [JsonPropertyName("code")]
        [JsonPropertyOrder(1)]
        public long Id { get; set; }


        [JsonPropertyName("first_name")]
        [JsonPropertyOrder(3)]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        [JsonPropertyOrder(4)]
        public string LastName { get; set; }

        [JsonPropertyOrder(2)]
        public string Address { get; set; }


        [JsonPropertyOrder(5)]
        [JsonConverter(typeof(GenderSerializer))]
        public string Gender { get; set; }


        [JsonPropertyOrder(6)]
        // [JsonIgnore]
        // [JsonConverter(typeof(DateOnlySerializer))]
        public DateTime? BirthDay { get; set; }
    }
}
