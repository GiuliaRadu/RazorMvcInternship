using RazorMvc.Models;

namespace RazorMvc.Services
{
    public interface IAddMemberSubscriber
    {
        void OnAddMember(Intern member);
    }
}