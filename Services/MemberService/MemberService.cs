using LibraryAPI.Domain.DTOs.MemberDTOs;
using LibraryAPI.Domain.Models;
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

        public async Task GetorCreateMemberFromTokenClaimsAsync(string MicrosoftId, string Email, string FullNme)
        {
            var ExistingMember = await _memberRepo.GetByMicrosoftIdAsync( MicrosoftId );

            if (ExistingMember != null)
            {
                throw new InvalidOperationException("Member already exists.");
            }

            var newMember = new Member
            {
                MicrosoftId = MicrosoftId,
                Email = Email,
                FullName = FullNme
            };
            await _memberRepo.AddAsync( newMember );
        }
    }
    }

