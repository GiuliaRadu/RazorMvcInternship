using RazorMvc.Models;
using System.Collections.Generic;

namespace RazorMvc.Services
{
    public interface IInternshipService
    {
        Intern AddMember(Intern intern);
        IList<Intern> GetMembers();
        void RemoveMember(int index);
        void UpdateMember(Intern intern);
    }
}