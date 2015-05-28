using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Validation;

namespace BowlingSPAService.Repository.Repositories
{
    /// <summary>
    /// This a generic repository interface with defined methods to support an EF implementation. 
    /// All other repository interfaces should only extend from this where there isn't already an ability to manipulate the underlying data.
    /// Since many of the methods defined allow expressions, this should handle a great deal of data extraction needs.
    /// </summary>
    /// <remarks>This is an abridged implementation of the Interface derived from the IRepository.cs found on GitHub: http://bit.ly/1nKjzGc </remarks>
    public interface IRepository
    {

        TEntity Add<TEntity>(TEntity entity) where TEntity : class;        

        void Delete<TEntity>(object id) where TEntity : class;

        void Delete<TEntity>(TEntity entity) where TEntity : class;

        void Delete<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        
        int ExecuteRawQuery(string query, Hashtable queryParams);

        IEnumerable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;      

        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;

        TEntity GetByID<TEntity>(object id) where TEntity : class;

        IEnumerable<DbEntityValidationResult> GetDbEntityValidationErrors();

        IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class;

        IQueryable<TEntity> GetQuery<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

    }
}
