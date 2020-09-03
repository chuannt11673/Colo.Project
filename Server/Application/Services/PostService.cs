using Application.Extensions;
using Application.Models;
using Core.Entities;
using Elect.DI.Attributes;
using Elect.Mapper.AutoMapper.IQueryableUtils;
using Elect.Mapper.AutoMapper.ObjUtils;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IPostService
    {
        Task<PostModel> Create(PostCreateModel model);
        Task<PagingationModel<PostModel>> Gets(PagingationRequestModel pagingationRequestModel);
        Task<PagingationModel<PostModel>> Gets(Guid userId, PagingationRequestModel pagingationRequestModel);
        Task<PostModel> GetById(Guid id);
        Task Like(Guid postId);
        Task<PostCommentModel> Comment(PostCommentCreateModel model);
        Task<IEnumerable<PostCommentModel>> GetComments(Guid postId);
    }

    [ScopedDependency(ServiceType = typeof(IPostService))]
    public class PostService : IPostService
    {
        private readonly IGenericRepo<PostEntity> _postRepo;
        private readonly IGenericRepo<PostImageEntity> _postImageRepo;
        private readonly IGenericRepo<PostLikeEntity> _postLikeRepo;
        private readonly IGenericRepo<PostCommentEntity> _postCommentRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly HttpContext _httpContext;
        public PostService(IGenericRepo<PostEntity> postRepo, IGenericRepo<PostImageEntity> postImageRepo,
            IGenericRepo<PostLikeEntity> postLikeRepo,
            IGenericRepo<PostCommentEntity> postCommentRepo,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor)
        {
            _postRepo = postRepo;
            _postImageRepo = postImageRepo;
            _postLikeRepo = postLikeRepo;
            _postCommentRepo = postCommentRepo;
            _unitOfWork = unitOfWork;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<PostCommentModel> Comment(PostCommentCreateModel model)
        {
            var userId = _httpContext.User.Id();

            var postEntity = _postRepo.FindById(model.PostId);
            if (postEntity != null)
            {
                var postCommentEntity = new PostCommentEntity
                {
                    UserId = userId,
                    PostId = model.PostId,
                    Content = model.Content
                };

                _postCommentRepo.Add(postCommentEntity);
                _unitOfWork.Commit();

                await _unitOfWork.Context.Entry(postCommentEntity).Reference(x => x.User).LoadAsync();

                return postCommentEntity.MapTo<PostCommentModel>();
            }

            return new PostCommentModel();
        }

        public Task<PostModel> Create(PostCreateModel model)
        {

            var postEntity = model.MapTo<PostEntity>();

            var userId = _httpContext.User.Id();
            postEntity.UserId = userId;

            _postRepo.Add(postEntity);

            var postImageEntities = new List<PostImageEntity>();
            foreach (var fileId in model.FileIds)
            {
                var postImageEntity = new PostImageEntity
                {
                    PostId = postEntity.Id,
                    FileId = fileId
                };

                postImageEntities.Add(postImageEntity);
            }

            _postImageRepo.AddRange(postImageEntities.ToArray());

            _unitOfWork.Commit();

            var loadUser = _unitOfWork.Context.Entry(postEntity).Reference(x => x.User).Query().Include(x => x.UserFiles).LoadAsync();
            var loadImages = _unitOfWork.Context.Entry(postEntity).Collection(x => x.PostImages).Query().Include(x => x.File).LoadAsync();

            var loadTask = Task.WhenAll(loadUser, loadImages);
            loadTask.Wait();

            return Task.FromResult(postEntity.MapTo<PostModel>());
        }

        public Task<PostModel> GetById(Guid id)
        {
            var entity = _postRepo.FindById(id);
            if (entity != null)
            {
                var model = entity.MapTo<PostModel>();
                return Task.FromResult(model);
            }

            return Task.FromResult(new PostModel());
        }

        public Task<IEnumerable<PostCommentModel>> GetComments(Guid postId)
        {
            var entities = _postCommentRepo.Get(x => x.PostId == postId).ToList();

            var models = entities.AsQueryable().QueryTo<PostCommentModel>().AsEnumerable();

            return Task.FromResult(models);
        }

        public Task<PagingationModel<PostModel>> Gets(PagingationRequestModel pagingationRequestModel)
        {
            var queryable = _postRepo.Get().OrderByDescending(x => x.CreatedDateTime);

            var result = PagingationModel<PostModel>.CreateLazyLoading(queryable, pagingationRequestModel.PageIndex, pagingationRequestModel.PageSize);

            return Task.FromResult(result);
        }

        public Task<PagingationModel<PostModel>> Gets(Guid userId, PagingationRequestModel pagingationRequestModel)
        {
            var queryable = _postRepo.Get(x => x.UserId == userId).OrderByDescending(x => x.CreatedDateTime);

            var result = PagingationModel<PostModel>.CreateLazyLoading(queryable, pagingationRequestModel.PageIndex, pagingationRequestModel.PageSize);

            return Task.FromResult(result);
        }

        public Task Like(Guid postId)
        {
            var userId = _httpContext.User.Id();

            var isAny = _postRepo.Get(x => x.Id == postId).AsNoTracking().Any();
            if (isAny)
            {
                var entity = new PostLikeEntity
                {
                    PostId = postId,
                    UserId = userId
                };

                _postLikeRepo.Add(entity);
                _unitOfWork.Commit();
            }

            return Task.CompletedTask;
        }
    }
}
