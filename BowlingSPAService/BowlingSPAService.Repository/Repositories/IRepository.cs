using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Validation;

namespace BowlingSPAService.Repository.Repositories
{
    /// <summary>
    /// The is a generic repository interface with defined methods to support an EF implementation. 
    /// All other repository interfaces should only extend from this where there isn't already an ability to manipulate the underlying data.
    /// </summary>
    public interface IRepository
    {

        void Add<TEntity>(TEntity entity) where TEntity : class;

        void Attach<TEntity>(TEntity entity) where TEntity : class;

        int Count<TEntity>() where TEntity : class;

        int Count<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;

        void Delete<TEntity>(object id) where TEntity : class;

        void Delete<TEntity>(TEntity entity) where TEntity : class;

        void Delete<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;

        void Edit<TEntity>(TEntity entity) where TEntity : class;

        int ExecuteRawQuery(string query, Hashtable queryParams);

        IEnumerable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;

        TEntity FindOne<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;

        TEntity First<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;        

        IEnumerable<TEntity> Get<TEntity, TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class;

        IEnumerable<TEntity> Get<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class;

        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;

        TEntity GetByID<TEntity>(object id) where TEntity : class;

        TEntity GetByKey<TEntity>(object keyValue) where TEntity : class;

        IEnumerable<DbEntityValidationResult> GetDbEntityValidationErrors();

        IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class;

        IQueryable<TEntity> GetQuery<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        TEntity Single<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

    }
}
