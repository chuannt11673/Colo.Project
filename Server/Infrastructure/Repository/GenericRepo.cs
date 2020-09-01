using Core.Entities;
using Elect.DI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public interface IGenericRepo<T> where T : BaseEntity
    {
        T FindById(params object[] keys);
        IQueryable<T> Get();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetFromSql(string sql, params object[] parameters);
        void Add(T entity);
        void AddRange(T[] entities);
        void Delete(T entity);
        void Update(T entity, params Expression<Func<T, object>>[] properties);
    }

    [ScopedDependency(ServiceType = typeof(IGenericRepo<>))]
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

        public void AddRange(T[] entities)
        {
            var user = _httpContextAccessor.HttpContext.User;
            foreach (var entity in entities)
            {
                entity.CreatedDateTime = DateTimeOffset.UtcNow;
                entity.UpdatedDateTime = DateTimeOffset.UtcNow;
                if (user.Identity.IsAuthenticated)
                {
                    entity.CreatedBy = user.Identity.Name;
                    entity.UpdatedBy = user.Identity.Name;
                }
            }

            _dbSet.AddRange(entities);
        }

        public void Delete(T entity)
        {
            T existing = _dbSet.Find(entity);
            if (existing != null)
            {
                _dbSet.Remove(existing);
            }
        }

        public T FindById(params object[] keys)
        {
            return _dbSet.Find(keys);
        }

        public IQueryable<T> Get()
        {
            return _dbSet;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IQueryable<T> GetFromSql(string sql, params object[] parameters)
        {
            return _dbSet.FromSqlRaw(sql, parameters);
        }

        public void Update(T entity, params Expression<Func<T, object>>[] properties)
        {
            // check if entity is tracked
            if (!Exists(entity))
            {
                _dbSet.Attach(entity);
                entity.UpdatedDateTime = DateTimeOffset.UtcNow;
                foreach (var property in properties)
                {
                    _unitOfWork.Context.Entry(entity).Property(property).IsModified = true;                    
                }
            }
        }

        private bool Exists(T entity)
        {
            return _dbSet.Local.Any(e => e == entity);
        }
    }
}
