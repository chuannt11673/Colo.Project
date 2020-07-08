using Application.Extensions;
using Application.Models;
using Core.Entities;
using Elect.DI.Attributes;
using Elect.Mapper.AutoMapper.IQueryableUtils;
using Elect.Mapper.AutoMapper.ObjUtils;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        Task<UserModel> Register(UserCreateModel model);
        Task<UserModel> SearchEmail(string email);
        Task AddFriend(Guid userId);
        Task AcceptFriend(Guid userId);
        Task<bool> IsAnyUserEmail(string email);
        Task<List<UserModel>> GetFriends();
        Task<List<UserModel>> GetFriendRequests();
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

        public Task AcceptFriend(Guid userId)
        {
            var request = _friendShipRepo.Get(x => x.SenderId == userId).FirstOrDefault();
            if (request != null)
            {
                request.State = FriendShipState.Accepted;
                _friendShipRepo.Update(request, x => x.State);
                _unitOfWork.Commit();
            }

            return Task.CompletedTask;
        }

        public Task AddFriend(Guid userId)
        {
            var entity = _userRepo.Get(x => x.Id == userId).FirstOrDefault();
            if (entity == null)
                throw new Exception("User doesn't exist");

            if (entity.Email == _httpContext.UserEmail())
                return Task.CompletedTask;

            _friendShipRepo.Add(new FriendShipEntity
            {
                SenderId = _httpContext.UserId(),
                ReceiverId = entity.Id,
                State = FriendShipState.Requested
            });
            _unitOfWork.Commit();
            return Task.CompletedTask;
        }

        public Task<List<UserModel>> GetFriendRequests()
        {
            var userId = _httpContext.UserId();
            var users = _friendShipRepo.Get(x => x.ReceiverId == userId && x.State == FriendShipState.Requested).Select(x => x.Sender).QueryTo<UserModel>();

            return Task.FromResult(users.ToList());
        }

        public Task<List<UserModel>> GetFriends()
        {
            var userId = _httpContext.UserId();
            var users = _friendShipRepo.Get(x => x.SenderId == userId && x.State == FriendShipState.Accepted).Select(x => x.Receiver).QueryTo<UserModel>()
                .Union(_friendShipRepo.Get(x => x.ReceiverId == userId && x.State == FriendShipState.Accepted).Select(x => x.Sender).QueryTo<UserModel>());

            return Task.FromResult(users.ToList());
        }

        public Task<bool> IsAnyUserEmail(string email)
        {
            var isAny = _userRepo.Get(x => x.Email == email).Any();
            return Task.FromResult(isAny);
        }

        public Task<UserModel> Register(UserCreateModel model)
        {
            var userId = _httpContext.UserId();
            var userEmail = _httpContext.UserEmail();

            var entity = _userRepo.Get(x => x.Email == userEmail).FirstOrDefault();
            if (entity == null)
            {
                entity = model.MapTo<UserEntity>();
                entity.Id = userId;
                entity.Email = userEmail;
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

            var loggedInUserId = _httpContext.UserId();
            var isFriend = _friendShipRepo.Get(x => (x.SenderId == loggedInUserId && x.ReceiverId == entity.Id) ||
                (x.SenderId == entity.Id && x.ReceiverId == loggedInUserId)).Any();

            var userModel = entity.MapTo<UserModel>();
            userModel.IsFriend = isFriend || entity.Id == loggedInUserId;

            return Task.FromResult(userModel);
        }
    }
}
