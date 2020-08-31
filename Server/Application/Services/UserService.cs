using Application.Extensions;
using Application.Models;
using Core.Entities;
using Elect.DI.Attributes;
using Elect.Mapper.AutoMapper.IQueryableUtils;
using Elect.Mapper.AutoMapper.ObjUtils;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        Task<UserModel> GetUserInfo();
        Task<UserModel> SearchEmail(string email);
        Task AddFriend(Guid userId);
        Task AcceptFriend(Guid userId);
        Task<bool> IsAnyUserEmail(string email);
        Task<List<UserModel>> GetFriends();
        Task<List<UserModel>> GetFriendRequests();
        Task<FileModel> UpdateUserFile(IUserFileUpdateModel model);
        Task UpdateUserInfo(UserUpdateModel model);
        Task<List<UserModel>> SuggestFriends();
        Task LikeUser(Guid userId);
        Task<IEnumerable<UserLikeModel>> GetUserLikes();
        Task<FriendShipModel> GetFriendShipState(Guid userId);
    }

    [ScopedDependency(ServiceType = typeof(IUserService))]
    public class UserService : IUserService
    {
        private readonly HttpContext _httpContext;
        private readonly IGenericRepo<UserEntity> _userRepo;
        private readonly IGenericRepo<FriendShipEntity> _friendShipRepo;
        private readonly IGenericRepo<UserFileEntity> _userFileRepo;
        private readonly IGenericRepo<UserLikeEntity> _userLikeRepo;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IHttpContextAccessor httpContextAccessor,
            IGenericRepo<UserEntity> userRepo,
            IGenericRepo<FriendShipEntity> friendShipRepo,
            IGenericRepo<UserFileEntity> userFileRepo,
            IGenericRepo<UserLikeEntity> userLikeRepo,
            IUnitOfWork unitOfWork)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _userRepo = userRepo;
            _friendShipRepo = friendShipRepo;
            _userFileRepo = userFileRepo;
            _userLikeRepo = userLikeRepo;
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

            if (entity.Email == _httpContext.User.Email())
                return Task.CompletedTask;

            _friendShipRepo.Add(new FriendShipEntity
            {
                SenderId = _httpContext.User.Id(),
                ReceiverId = entity.Id,
                State = FriendShipState.Requested
            });

            _unitOfWork.Commit();

            return Task.CompletedTask;
        }

        public Task<List<UserModel>> GetFriendRequests()
        {
            var userId = _httpContext.User.Id();
            var users = _friendShipRepo.Get(x => x.ReceiverId == userId && x.State == FriendShipState.Requested)
                .Select(x => x.Sender).ToList();

            var result = users.AsQueryable().QueryTo<UserModel>().ToList();
            return Task.FromResult(result);
        }

        public Task<List<UserModel>> GetFriends()
        {
            var userId = _httpContext.User.Id();

            var user = _userRepo.Get(x => x.Id == userId).FirstOrDefault();

            if (user != null)
            {
                var friends = user.Friends.Select(x => x.MapTo<UserModel>()).ToList();

                return Task.FromResult(friends);
            }

            return Task.FromResult(new List<UserModel>());
        }

        public Task<bool> IsAnyUserEmail(string email)
        {
            var isAny = _userRepo.Get(x => x.Email == email).Any();
            return Task.FromResult(isAny);
        }

        public Task<UserModel> GetUserInfo()
        {
            var userId = _httpContext.User.Id();
            var userEmail = _httpContext.User.Email();

            (var name, var domain) = GetEmailInfo(userEmail);

            var entity = _userRepo.Get(x => x.Id == userId).FirstOrDefault();
            
            if (entity is null)
            {
                entity = new UserEntity
                {
                    Id = userId,
                    Email = userEmail,
                    Name = name,
                    Birthday = DateTimeOffset.UtcNow.Date
                };

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

            var loggedInUserId = _httpContext.User.Id();

            var isFriend = _friendShipRepo.Get(x => (x.SenderId == loggedInUserId && x.ReceiverId == entity.Id) ||
                (x.SenderId == entity.Id && x.ReceiverId == loggedInUserId)).Any();

            var userModel = entity.MapTo<UserModel>();

            return Task.FromResult(userModel);
        }

        public Task<FileModel> UpdateUserFile(IUserFileUpdateModel model)
        {
            var userId = _httpContext.User.Id();

            var entity = new UserFileEntity
            {
                UserId = userId,
                FileId = model.FileId,
                Type = model.Type
            };

            _userFileRepo.Add(entity);
            _unitOfWork.Commit();

            _unitOfWork.Context.Entry(entity).Reference(x => x.File).Load();
            return Task.FromResult(entity.File.MapTo<FileModel>());
        }

        public Task UpdateUserInfo(UserUpdateModel model)
        {
            var userEntity = model.MapTo<UserEntity>();

            var userId = _httpContext.User.Id();
            userEntity.Id = userId;

            _userRepo.Update(userEntity, a => a.Name, a => a.Phone, a => a.Birthday, a => a.Gender);

            _unitOfWork.Commit();

            return Task.CompletedTask;
        }

        public Task<List<UserModel>> SuggestFriends()
        {
            var userId = _httpContext.User.Id();

            var users = _userRepo.Get(x => x.Id != userId).ToList();
            var friends = users.Select(x => x.MapTo<UserModel>()).ToList();

            return Task.FromResult(friends);
        }

        public Task LikeUser(Guid userId)
        {
            var currentUserId = _httpContext.User.Id();

            var user = _userRepo.FindById(userId);
            if (user != null)
            {
                var userLikeEntity = new UserLikeEntity
                {
                    SenderId = currentUserId,
                    ReceiverId = userId,
                    State = UserLikeState.Like
                };

                _userLikeRepo.Add(userLikeEntity);
                _unitOfWork.Commit();
            }

            return Task.CompletedTask;
        }

        private (string name, string domain) GetEmailInfo(string email)
        {
            var regex = new Regex(@"(?<name>[a-zA-Z0-9.]+)@(?<domain>[a-zA-Z0-9.]+)");

            var match = regex.Match(email);

            if (match.Success)
            {
                var name = match.Groups["name"].Value;
                var domain = match.Groups["domain"].Value;

                return (name, domain);
            }

            return (string.Empty, string.Empty);
        }

        public Task<IEnumerable<UserLikeModel>> GetUserLikes()
        {
            var userId = _httpContext.User.Id();

            var userLikes = _userLikeRepo.Get(x => x.SenderId == userId).QueryTo<UserLikeModel>().AsEnumerable();

            return Task.FromResult(userLikes);
        }

        public Task<FriendShipModel> GetFriendShipState(Guid userId)
        {
            var currentUserId = _httpContext.User.Id();

            var entity = _friendShipRepo.FindById(userId, currentUserId);

            if (entity is null)
                entity = _friendShipRepo.FindById(currentUserId, userId);

            return Task.FromResult(entity.MapTo<FriendShipModel>());
        }
    }
}
