using AutoMapper;
using LibraryAPI.DTOs.AuthenticationDTOs;
using LibraryAPI.DTOs.BookDTOs;
using LibraryAPI.DTOs.FineDtos;
using LibraryAPI.DTOs.LoanDtos;
using LibraryAPI.DTOs.MemberDTOs;
using LibraryAPI.Models;

namespace LibraryAPI.LibraryMappingProfile
{
    public class LibraryMappingProfile:Profile
    {
        public LibraryMappingProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<CreateBookDto, Book>()
                .ForMember(dest => dest.AvailableCopies, opt => opt.MapFrom(src => src.TotalCopies))
                .ReverseMap();
         

            CreateMap<Member, MemberViewDto>().ReverseMap();
            CreateMap<MemberCreateDto, Member>().ReverseMap();
            CreateMap<MemberUpdateDto, Member>().ReverseMap();

            CreateMap<Loan, LoanViewDto>()
          .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
          .ForMember(dest => dest.MemberName, opt => opt.MapFrom(src => src.Member.UserId));
            CreateMap<LoanCreateDto, Loan>().ReverseMap();
            CreateMap<LoanUpdateDto, Loan>().ReverseMap();

            CreateMap<Fine, FineViewDto>().ReverseMap();
            CreateMap<FineCreateDto, Fine>().ReverseMap();
            CreateMap<FineUpdateDto, Fine>().ReverseMap();

            CreateMap<RegisterDto, ApplicationUser>()
          .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

        }

    }
}
