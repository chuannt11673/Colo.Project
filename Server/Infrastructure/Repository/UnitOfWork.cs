using Elect.DI.Attributes;
using Infrastructure.Data;
using System;

namespace Infrastructure.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        CoreDbContext Context { get; }
        void Commit();
    }
    
    [ScopedDependency(ServiceType = typeof(IUnitOfWork))]
    public class UnitOfWork : IUnitOfWork
    {
        public CoreDbContext Context { get; }

        public UnitOfWork(CoreDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
