using AutoMapper;
using LastBeer.Back.Models;

namespace LastBeer.Back.Mappers
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserInsertDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}
