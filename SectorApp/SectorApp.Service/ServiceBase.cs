﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SectorApp.DataAccess.Models;
using SectorApp.Repository;
using SectorApp.Repository.Infrastructure;

namespace SectorApp.Service
{
    public interface IServiceBase<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> Get();
        TEntity GetSingle(int id);
        TEntity SaveOrUpdate(TEntity entity);
        void Delete(TEntity entity);
    }

    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
    {
        public readonly IRepository<TEntity> Repository;
        public readonly IUnitOfWork UnitOfWork;

        public ServiceBase(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        public IEnumerable<TEntity> Get()
        {
            using (UnitOfWork.Context.Database.BeginTransaction())
            {
                var result = Repository.Get();
                return result;
            }
        }

        public TEntity GetSingle(int id)
        {
            using (UnitOfWork.Context.Database.BeginTransaction())
            {
                var result = Repository.Get(id);
                return result;
            }
        }

        public TEntity SaveOrUpdate(TEntity entity)
        {
            using (var tran = UnitOfWork.Context.Database.BeginTransaction())
            {
                if (entity.IsNew)
                {
                    var result = Repository.Add(entity);
                    tran.Commit();
                    return result;
                }
                else
                {
                    var result = Repository.Update(entity);
                    tran.Commit();
                    return result;
                }
            }
        }

        public void Delete(TEntity entity)
        {
            using (var tran = UnitOfWork.Context.Database.BeginTransaction())
            {
                Repository.Delete(entity);
                tran.Commit();
            }
        }
    }
}
