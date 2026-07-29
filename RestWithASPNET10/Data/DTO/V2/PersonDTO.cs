using System.Text.Json.Serialization;

namespace RestWithASPNET10.Data.DTO.V2
{
    public class PersonDTO
    {

        public long Id { get; set; }
        public string FirstName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string LastName { get; set; }

        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDay { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Age { get; set; }

        [JsonIgnore]
        public bool IsAdult => Age >= 18;

        [JsonIgnore]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
