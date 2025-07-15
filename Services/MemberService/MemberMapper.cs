
using LibraryAPI.Domain.DTOs.MemberDTOs;
using LibraryAPI.Domain.Models;
using Microsoft.Identity.Client;

namespace LibraryAPI.Services.MemberService
{
    public class MemberMapper
    {
        public MemberDto ToDto(Member member)
        {
            return new MemberDto
            {
                MemberId = member.Id,
                MicrosoftId = member.MicrosoftId,
                Email = member.Email,
                FullName = member.FullName,
            };
        }

        public Member ToEntity(MemberDto memberDto)
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