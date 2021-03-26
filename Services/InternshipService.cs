using RazorMvc.Models;
using System;

namespace RazorMvc.Services
{
    public class InternshipService
    {
        private readonly InternshipClass _internshipClass = new ();

        public void RemoveMember(int index)
        {
            _internshipClass.Members.RemoveAt(index);
        }

        public string AddMember(string member)
        {
            _internshipClass.Members.Add(member);
            return member;
        }

        public InternshipClass GetClass()
        {
            return _internshipClass;
        }

        internal void UpdateMember(int index, string name)
        {
            _internshipClass.Members[index] = name;
        }
    }
}
