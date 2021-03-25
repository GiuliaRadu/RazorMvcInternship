using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorMvc.Models
{
    public class InternshipClass
    {
        private List<string> _members;

        public InternshipClass()
        {
            _members = new List<string>
            {
                "Collegue1",
                "Collegue2",
                "Collegue3",
            };
        }

        public IList<string> Members
        {
            get { return _members; }
        }
    }
}
