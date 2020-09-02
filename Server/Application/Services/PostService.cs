using Application.Extensions;
using Application.Models;
using Core.Entities;
using Elect.DI.Attributes;
using Elect.Mapper.AutoMapper.ObjUtils;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IPostService
    {
        Task<PostModel> Create(PostCreateModel model);
        Task<PagingationModel<PostModel>> Gets(PagingationRequestModel pagingationRequestModel);
        Task<PostModel> GetById(Guid id);
    }

    [ScopedDependency(ServiceType = typeof(IPostService))]
    public class PostService : IPostService
    {
        private readonly IGenericRepo<PostEntity> _postRepo;
        private readonly IGenericRepo<PostImageEntity> _postImageRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly HttpContext _httpContext;
        public PostService(IGenericRepo<PostEntity> postRepo, IGenericRepo<PostImageEntity> postImageRepo, IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor)
        {
            _postRepo = postRepo;
            _postImageRepo = postImageRepo;
            _unitOfWork = unitOfWork;
            _httpContext = httpContextAccessor.HttpContext;
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

            Task.WhenAll(loadUser, loadImages).Wait();

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

        public Task<PagingationModel<PostModel>> Gets(PagingationRequestModel pagingationRequestModel)
        {
            var queryable = _postRepo.Get().OrderByDescending(x => x.CreatedDateTime);

            var result = PagingationModel<PostModel>.CreateLazyLoading<PostEntity>(queryable, pagingationRequestModel.PageIndex, pagingationRequestModel.PageSize);

            return Task.FromResult(result);
        }
    }
}
