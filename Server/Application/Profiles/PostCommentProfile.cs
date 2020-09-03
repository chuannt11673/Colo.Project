using Application.Models;
using AutoMapper;
using Core.Entities;
using Elect.Mapper.AutoMapper.IMappingExpressionUtils;
using Elect.Mapper.AutoMapper.ObjUtils;

namespace Application.Profiles
{
    public class PostCommentProfile : Profile
    {
        public PostCommentProfile()
        {
            CreateMap<PostCommentEntity, PostCommentModel>().IgnoreAllNonExisting()
                .ForMember(x => x.User, opt => opt.MapFrom(s => s.User.MapTo<BasicUserModel>()));
        }
    }
}
