using LibraryAPI.Data;
using LibraryAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repository.MemberRepo
{
    public class MemberRepository : IMemberRepo 
    {
        private readonly LibraryDbContext _context;

        public MemberRepository(LibraryDbContext context )
        {
            _context = context;
        }
        public async Task<Member> GetByMicrosoftIdAsync(string microsoftId)
        {
            return await _context.Members
                .FirstOrDefaultAsync(m => m.MicrosoftId == microsoftId);
        }


        public async Task<Member> AddAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }

        
            
        
    }
    
}
