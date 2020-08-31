using Application.Models;
using AutoMapper;
using Core.Entities;
using Elect.Mapper.AutoMapper.IMappingExpressionUtils;

namespace Application.Profiles
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<NotificationModel, NotificationEntity>().IgnoreAllNonExisting();
            CreateMap<NotificationEntity, NotificationModel>().IgnoreAllNonExisting();
        }
    }
}
