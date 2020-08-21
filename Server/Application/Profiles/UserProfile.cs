using Application.Models;
using AutoMapper;
using Core.Entities;
using Elect.Mapper.AutoMapper.IMappingExpressionUtils;

namespace Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateModel, UserEntity>().IgnoreAllNonExisting();
            CreateMap<UserUpdateModel, UserEntity>().IgnoreAllNonExisting();
            CreateMap<UserEntity, UserModel>().IgnoreAllNonExisting();
        }
    }
}
