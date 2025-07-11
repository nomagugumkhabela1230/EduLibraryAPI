using LibraryAPI.Domain.DTOs.MemberDTOs;
using LibraryAPI.Repository.MemberRepo;
using System.Security.Claims;

namespace LibraryAPI.Services.MemberService
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepo _memberRepo;
        private readonly MemberMapper _mapper;

        public MemberService(IMemberRepo memberRepo, MemberMapper mapper )
        {
            _memberRepo = memberRepo;
            _mapper = mapper;
        }
        public async  Task<MapToDto> GetorCreateMemberFromTokenClaimsAsync(ClaimsPrincipal user)
        {
            var oid = user.FindFirst("oid")?.Value;
            var email = user.FindFirst("preferred_username")?.Value?? user.FindFirst("email")?.Value;
            var name = user.FindFirst("name")?.Value;

            if (string.IsNullOrEmpty(oid) || string.IsNullOrEmpty(email))
                throw new UnauthorizedAccessException("Missing required claims.");

            var existing = await _memberRepo.GetByMicrosoftIdAsync(oid);

         
            
        }
    }
}
