using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorMvc.Models
{
    public class Location
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NativeName { get; internal set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public List<Intern> LocalInterns { get; set; }

    }
}
