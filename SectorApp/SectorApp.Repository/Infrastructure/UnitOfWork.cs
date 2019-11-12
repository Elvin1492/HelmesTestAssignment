using System;
using SectorApp.DataAccess.Models;

namespace SectorApp.Repository.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        SectorAppContext Context { get; }
        void Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public SectorAppContext Context { get; }

        public UnitOfWork(SectorAppContext context)
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