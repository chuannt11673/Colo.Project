using Application.Models;
using AutoMapper;
using Core.Entities;
using Elect.Mapper.AutoMapper.IMappingExpressionUtils;

namespace Application.Profiles
{
    public class UserLikeProfile : Profile
    {
        public UserLikeProfile()
        {
            CreateMap<UserLikeEntity, UserLikeModel>().IgnoreAllNonExisting();
        }
    }
}
