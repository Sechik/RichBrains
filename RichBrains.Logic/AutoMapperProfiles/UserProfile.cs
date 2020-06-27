using AutoMapper;
using RichBrains.Data.Models;
using RichBrains.Logic.Models;

namespace RichBrains.Logic.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDb, UserDto>().ReverseMap();            
        }
    }
}
