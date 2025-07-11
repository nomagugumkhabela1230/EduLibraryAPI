using LibraryAPI.Domain.Models;

namespace LibraryAPI.Repository.MemberRepo
{
    public interface IMemberRepo
    {
        Task<Member> GetByMicrosoftIdAsync(string microsoftId);
        Task<Member> AddAsync(Member member);    
    }
}
