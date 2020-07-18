using Application.Models;
using AutoMapper;
using Core.Entities;
using Elect.Mapper.AutoMapper.IMappingExpressionUtils;
using Elect.Mapper.AutoMapper.ObjUtils;

namespace Application.Profiles
{
    public class ChatProfile : Profile
    {
        public ChatProfile()
        {
            CreateMap<ChatEntity, ChatModel>().IgnoreAllNonExisting()
                .ForMember(x => x.FromUserEmail, opts => opts.MapFrom(s => s.FromUser.Email))
                .ForMember(x => x.ToUserEmail, opts => opts.MapFrom(s => s.ToUser.Email))
                .ReverseMap();
        }
    }
}
