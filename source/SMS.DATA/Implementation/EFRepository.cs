﻿using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using SMS.DATA.Infrastructure;

namespace SMS.DATA.Implementation
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        public EfRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            _unitOfWork.Context.Set<T>().Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(T entity)
        {
            T existing = _unitOfWork.Context.Set<T>().Find(entity);
            if (existing != null) _unitOfWork.Context.Set<T>().Remove(existing);
        }

        public IQueryable<T> Get()
        {
            return _unitOfWork.Context.Set<T>();
        }
        public IQueryable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.Set<T>().Where(predicate);
        }

        public void Update(T entity)
        {
            //_unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<T>().AddOrUpdate(entity);
            _unitOfWork.Commit();
        }

        public IQueryable<T> Table => _unitOfWork.Context.Set<T>().AsNoTracking();
        public IQueryable<T> TableNoTracking => _unitOfWork.Context.Set<T>().AsNoTracking();
        #region Methods
        /// <summary>
        /// Soft Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void SoftDelete(T entity)
        {
            if (entity == null)
                throw new NullReferenceException();

            try
            {
                Update(entity);
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw exception;
            }
        }

        [Obsolete]
        public void ExecuteSqlCommand(string sqlQuery)
        {
            _ = _unitOfWork.Context.ExecuteSqlCommand(sqlQuery);
        }

        #endregion
    }
}
