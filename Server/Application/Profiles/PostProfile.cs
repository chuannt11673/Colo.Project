using Application.Models;
using AutoMapper;
using Core.Entities;
using Elect.Mapper.AutoMapper.IMappingExpressionUtils;
using Elect.Mapper.AutoMapper.IQueryableUtils;
using Elect.Mapper.AutoMapper.ObjUtils;
using System.Linq;

namespace Application.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostCreateModel, PostEntity>().IgnoreAllNonExisting();

            CreateMap<PostEntity, PostModel>().IgnoreAllNonExisting()
                .ForMember(x => x.User, opt => opt.MapFrom(s => s.User.MapTo<BasicUserModel>()))
                .ForMember(x => x.FileModels, opt => opt.MapFrom(x => x.PostImages.Select(x => x.File).AsQueryable().QueryTo<FileModel>()))
                .ForMember(x => x.LikedUsers, opt => opt.MapFrom(x => x.PostLikes.Select(x => x.User).AsQueryable().QueryTo<BasicUserModel>()));
        }
    }
}
