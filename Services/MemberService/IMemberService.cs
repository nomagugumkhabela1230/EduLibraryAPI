using LibraryAPI.Domain.DTOs.MemberDTOs;
using System.Security.Claims;

namespace LibraryAPI.Services.MemberService
{
    public interface IMemberService
    {
        Task<MapToDto> GetorCreateMemberFromTokenClaimsAsync(ClaimsPrincipal user);
    }
}
