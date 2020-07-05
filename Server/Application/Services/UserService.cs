using Application.Models;
using Core.Entities;
using Elect.DI.Attributes;
using Elect.Mapper.AutoMapper.ObjUtils;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        Task<UserModel> Register(UserCreateModel model);
        Task<UserModel> SearchEmail(string email);
        Task AddFriend(Guid userId);
    }

    [ScopedDependency(ServiceType = typeof(IUserService))]
    public class UserService : IUserService
    {
        private readonly HttpContext _httpContext;
        private readonly IGenericRepo<UserEntity> _userRepo;
        private readonly IGenericRepo<FriendShipEntity> _friendShipRepo;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IHttpContextAccessor httpContextAccessor,
            IGenericRepo<UserEntity> userRepo,
            IGenericRepo<FriendShipEntity> friendShipRepo,
            IUnitOfWork unitOfWork)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _userRepo = userRepo;
            _friendShipRepo = friendShipRepo;
            _unitOfWork = unitOfWork;
        }

        public Task AddFriend(Guid userId)
        {            
            var entity = _userRepo.Get(x => x.Id == userId).FirstOrDefault();            
            if (entity == null)
                throw new Exception("User doesn't exist");

            if (entity.Email == _httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value)
                return Task.CompletedTask;

            _friendShipRepo.Add(new FriendShipEntity
            {
                SenderId = GetContextUserId(),
                ReceiverId = entity.Id,
                State = FriendShipState.Requested
            });
            _unitOfWork.Commit();
            return Task.CompletedTask;
        }

        public Task<UserModel> Register(UserCreateModel model)
        {
            var entity = _userRepo.Get(x => x.Email == model.Email).FirstOrDefault();
            if (entity == null)
            {
                entity = model.MapTo<UserEntity>();
                entity.Id = GetContextUserId();
                entity.Email = _httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
                _userRepo.Add(entity);
                _unitOfWork.Commit();
            }

            return Task.FromResult(entity.MapTo<UserModel>());
        }

        public Task<UserModel> SearchEmail(string email)
        {
            var entity = _userRepo.Get(x => x.Email == email).FirstOrDefault();
            if (entity == null)
                return Task.FromResult((UserModel)null);

            return Task.FromResult(entity.MapTo<UserModel>());
        }

        private Guid GetContextUserId()
        {
            var userId = _httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return Guid.Parse(userId);
        }
    }
}
