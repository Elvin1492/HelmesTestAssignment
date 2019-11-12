﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SectorApp.DataAccess.Models;
using SectorApp.Repository.Infrastructure;

namespace SectorApp.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        T Get(int id);
        T Add(T entity);
        void Delete(T entity);
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
           return entity;
        }

        public void Delete(T entity)
        {
            T existing = _sectorAppContext.Set<T>().Find(entity);
            if (existing != null) _sectorAppContext.Set<T>().Remove(existing);
        }

        public IEnumerable<T> Get()
        {
            return _sectorAppContext.Set<T>().AsEnumerable<T>();
        }

        public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _sectorAppContext.Set<T>().Where(predicate).AsEnumerable<T>();
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