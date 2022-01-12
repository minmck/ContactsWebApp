using AutoMapper;
using ContactsWebApp.Shared.Dto;
using ContactsWebApp.Shared.Entities;

namespace ContactsWebApp.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterRequestDto, User>();
            CreateMap<User, RegisterResponseDto>()
                .ForMember(r => r.FullName,
                    opt => opt.MapFrom(x => string.Join(' ', x.FirstName, x.LastName)));
            CreateMap<User, LoginResponseDto>();
        }
    }
}
