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
            CreateMap<UserEntity, UserModel>().IgnoreAllNonExisting()
                .ForMember(x => x.Avatar, opt => opt.MapFrom(s => s.Avatar.File.Url))
                .ForMember(x => x.Cover, opt => opt.MapFrom(s => s.Cover.File.Url));
        }
    }
}
