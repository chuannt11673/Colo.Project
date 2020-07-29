using Application.Models;
using AutoMapper;
using Core.Entities;
using Elect.Mapper.AutoMapper.IMappingExpressionUtils;
using Elect.Mapper.AutoMapper.IQueryableUtils;
using Elect.Mapper.AutoMapper.ObjUtils;
using System.Linq;

namespace Application.Profiles
{
    public class ChatProfile : Profile
    {
        public ChatProfile()
        {
            CreateMap<ChatEntity, ChatModel>().IgnoreAllNonExisting()
                .ForMember(x => x.FromUserEmail, opts => opts.MapFrom(s => s.FromUser.Email))
                .ForMember(x => x.ToUserEmail, opts => opts.MapFrom(s => s.ToUser.Email))
                .ForMember(x => x.FileModels, opts => opts.MapFrom(s => s.ChatFiles.Select(c => new FileModel { Id = c.FileId, FileName = c.File.FileName, Url = c.File.Url })))
                .ReverseMap();
        }
    }
}
