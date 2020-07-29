using Application.Models;
using AutoMapper;
using Core.Entities;
using Elect.Mapper.AutoMapper.IMappingExpressionUtils;

namespace Application.Profiles
{
    public class ChatFileProfile : Profile
    {
        public ChatFileProfile()
        {
            CreateMap<ChatFileEntity, FileModel>().IgnoreAllNonExisting()
                .ForMember(x => x.Id, opts => opts.MapFrom(s => s.FileId))
                .ForMember(x => x.FileName, opts => opts.MapFrom(s => s.File.FileName))
                .ForMember(x => x.Url, opts => opts.MapFrom(s => s.File.Url));
        }
    }
}
