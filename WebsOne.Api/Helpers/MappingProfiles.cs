using AutoMapper;
using Models.DataTransferObjects;
using Models.Entities;

namespace WebsOne.Api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
