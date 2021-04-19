using System;
using System.Text.Json.Serialization;

namespace RazorMvc.Models
{
    public class Intern
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfJoin { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Location Location { get; set; }
    }
}
