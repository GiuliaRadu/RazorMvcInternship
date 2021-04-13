using System.Linq;
using RazorMvc.Data;
using RazorMvc.Models;
using System.Collections.Generic;
using RazorMvc.Hubs;

namespace RazorMvc.Services
{
    public class InternshipService : IInternshipService
    {
        private readonly InternshipClass _internshipClass = new ();

        public void RemoveMember(int index)

        {
            _internshipClass.Members.RemoveAt(index);
        }

        public Intern AddMember(Intern intern)
        {
            _internshipClass.Members.Add(intern);
            return intern;
        }

        public IList<Intern> GetMembers()
        {
            return _internshipClass.Members;
        }

        public void UpdateMember(Intern intern)
        {
            _internshipClass.Members[intern.Id] = intern;
        }
    }
}