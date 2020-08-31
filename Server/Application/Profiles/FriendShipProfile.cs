using Application.Models;
using AutoMapper;
using Core.Entities;
using Elect.Mapper.AutoMapper.IMappingExpressionUtils;

namespace Application.Profiles
{
    public class FriendShipProfile : Profile
    {
        public FriendShipProfile()
        {
            CreateMap<FriendShipEntity, FriendShipModel>().IgnoreAllNonExisting();
        }
    }
}
