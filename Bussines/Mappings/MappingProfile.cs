using AutoMapper;
using Entities.Concrate;
using Entities.Dtos.User;

namespace Bussines.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, UserDetailDto>();
            CreateMap<UserDetailDto, AppUser>();

            CreateMap<AppUser, UserDto>();
            CreateMap<UserDto, AppUser>();

            CreateMap<AppUser, UserAddDto>();
            CreateMap<UserAddDto, AppUser>();

            CreateMap<AppUser, UserUpdateDto>();
            CreateMap<UserUpdateDto, AppUser>();

            CreateMap<UserDto, UserUpdateDto>();
            CreateMap<UserUpdateDto, UserDto>();


            CreateMap<UserDetailDto, UserDto>();
            CreateMap<UserDto, UserDetailDto>();
        }
    }
}
