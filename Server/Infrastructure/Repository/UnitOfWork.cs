using Infrastructure.Data;
using System;

namespace Infrastructure.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        CoreDbContext Context { get; }
        void Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public CoreDbContext Context { get; }

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
