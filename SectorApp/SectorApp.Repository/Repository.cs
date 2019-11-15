using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SectorApp.DataAccess.Models;

namespace SectorApp.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        T Get(int id);
        T Add(T entity);
        void Delete(T entity);
        IEnumerable<T> DeleteWhere(Expression<Func<T, bool>> predicate);
        T Update(T entity);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SectorAppContext _sectorAppContext;
        public Repository(SectorAppContext unitOfWork)
        {
            _sectorAppContext = unitOfWork;
        }

        public T Add(T entity)
        {
           _sectorAppContext.Set<T>().Add(entity);
           _sectorAppContext.SaveChanges();
           return entity;
        }

        public void Delete(T entity)
        {
            var existing = _sectorAppContext.Set<T>().Find(entity);
            if (existing != null) _sectorAppContext.Set<T>().Remove(existing);
        }

        public IEnumerable<T> DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _sectorAppContext.Set<T>().Where(predicate);

            foreach (var entity in entities)
            {
                _sectorAppContext.Entry(entity).State = EntityState.Deleted;
            }

            _sectorAppContext.SaveChanges();
            return entities;
        }


        public IEnumerable<T> Get()
        {
            return _sectorAppContext.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _sectorAppContext.Set<T>().Where(predicate).AsEnumerable();
        }

        public T Get(int id)
        {
            return _sectorAppContext.Set<T>().Find(id);
        }

        public T Update(T entity)
        {
            _sectorAppContext.Entry(entity).State = EntityState.Modified;
            _sectorAppContext.Set<T>().Attach(entity);
            return entity;
        }
    }
}