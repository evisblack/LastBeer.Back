using AutoMapper;
using LastBeer.Back.Models;
using LastBeer.Back.Models.Dtos.BarDtos;
using LastBeer.Back.Models.Dtos.FavouriteBarDtos;
using LastBeer.Back.Models.Dtos.UserDtos;

namespace LastBeer.Back.Mappers
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserInsertDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<User, UserLoginResponseDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();

            CreateMap<FavouriteBar, FavouriteBarDto>().ReverseMap();

            CreateMap<Bar, BarDto>().ReverseMap();
            CreateMap<Bar, BarInsertDto>().ReverseMap();
        }
    }
}
