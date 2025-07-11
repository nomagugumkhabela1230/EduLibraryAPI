
using LibraryAPI.Domain.DTOs.MemberDTOs;
using LibraryAPI.Domain.Models;
using Microsoft.Identity.Client;

namespace LibraryAPI.Services.MemberService
{
    public class MemberMapper
    {
        public MapToDto ToDto(Member member)
        {
            return new MapToDto
            {
                MemberId = member.Id,
                MicrosoftId = member.MicrosoftId,
                Email = member.Email,
                FullName = member.FullName,
            };
        }

        public Member ToEntity(MapToDto memberDto)
        {
            return new Member
            {
                MicrosoftId = memberDto.MicrosoftId,
                Email = memberDto.Email,
                FullName = memberDto.FullName,

            };

        }
    }
}