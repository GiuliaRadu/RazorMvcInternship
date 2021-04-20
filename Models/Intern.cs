using System;
using System.Collections.Generic;
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

        public ICollection<Project> Projects { get; set; }
    }
}
