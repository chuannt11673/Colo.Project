using Application.Models;
using AutoMapper;
using Core.Entities;
using Elect.Mapper.AutoMapper.IMappingExpressionUtils;
using Elect.Mapper.AutoMapper.IQueryableUtils;
using Elect.Mapper.AutoMapper.ObjUtils;
using System.Linq;

namespace Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserModel>().IgnoreAllNonExisting()
                .ForMember(x => x.Avatar, opt => opt.MapFrom(s => s.Avatar.File.Url))
                .ForMember(x => x.Cover, opt => opt.MapFrom(s => s.Cover.File.Url))
                .ForMember(x => x.Friends, opt => opt.MapFrom(s => s.Friends.AsQueryable().QueryTo<BasicUserModel>()));

            CreateMap<UserEntity, BasicUserModel>().IgnoreAllNonExisting()
                .ForMember(x => x.Avatar, opt => opt.MapFrom(s => s.Avatar.File.Url))
                .ForMember(x => x.Cover, opt => opt.MapFrom(s => s.Cover.File.Url));

            CreateMap<UserUpdateModel, UserEntity>().IgnoreAllNonExisting()
                .ForMember(x => x.Birthday, opt => opt.MapFrom(s => s.Birthday.Date));
        }
    }
}
