using System;

namespace RazorMvc.Models
{
    public class Intern
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfJoin { get; set; }

        public Location Location { get; set; }
    }
}
