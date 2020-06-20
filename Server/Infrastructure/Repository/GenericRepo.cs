using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public interface IGenericRepo<T> where T : BaseEntity
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

    public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DbSet<T> _dbSet;
        public GenericRepo(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.Context.Set<T>();
            _httpContextAccessor = httpContextAccessor;
        }

        public void Add(T entity)
        {
            entity.CreatedDateTime = DateTimeOffset.UtcNow;
            entity.UpdatedDateTime = DateTimeOffset.UtcNow;

            var user = _httpContextAccessor.HttpContext.User;
            if (user.Identity.IsAuthenticated)
            {
                entity.CreatedBy = user.Identity.Name;
                entity.UpdatedBy = user.Identity.Name;
            }
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            T existing = _dbSet.Find(entity);
            if (existing != null)
            {
                _dbSet.Remove(existing);
            }
        }

        public IEnumerable<T> Get()
        {
            return _dbSet.AsEnumerable();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void Update(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _dbSet.Attach(entity);
        }
    }
}
