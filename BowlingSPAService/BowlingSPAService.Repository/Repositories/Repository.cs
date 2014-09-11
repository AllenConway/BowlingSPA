using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace BowlingSPAService.Repository.Repositories
{
    /// <summary>
    /// This is a generic repository implementation to support an Entity Framework implementation using DBContext.
    /// </summary>
    /// <remarks>This is an abridged class implementation derived from the GenericRepository.cs found on GitHub: http://bit.ly/1CscdRp </remarks>
    public class Repository : IRepository
    {
        internal DbContext Context;

        /// <summary>
        /// Generic repository taking in instance of DBContext for persistence via Entity Framework.
        /// </summary>
        /// <param name="context" type="DbContext"></param>
        public Repository(DbContext context)
        {
            //If disabled, serialization of POCOs will work, but we loose change tracking and lazy loading
            //Long term solution - transfer data to DTOs (ValueInjecter) to be sent across the wire.
            context.Configuration.ProxyCreationEnabled = false;
            Context = context;
        }

        /// <summary>
        /// Adds the specified entity
        /// </summary>
        /// <param name="entity" type="TEntity"></param>
        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Deletes the specified entity by ID provided.
        /// </summary>
        /// <param name="id" type="object"></param>
        public void Delete<TEntity>(object id) where TEntity : class
        {
            TEntity entityToDelete = Context.Set<TEntity>().Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity" type="TEntity"></param>
        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Context.Set<TEntity>().Attach(entity);
            }
            else
            {
                Context.Set<TEntity>().Remove(entity);
            }

            Context.SaveChanges();
        }

        /// <summary>
        /// Deletes one or many entities matching the specified criteria
        /// </summary>
        /// <param name="criteria" type="Expression"></param>
        public void Delete<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            IEnumerable<TEntity> records = Find(criteria);

            foreach (TEntity record in records)
            {
                Delete(record);
            }
        }

        /// <summary>
        /// Executes a raw SQL command against the repository
        /// </summary>
        /// <param name="query" type="string"></param>
        /// <param name="queryParams" type="Hashtable"></param>
        /// <returns>int</returns>
        public int ExecuteRawQuery(string query, Hashtable queryParams)
        {
            //Convert hashtable into collection of SqlParameter objects to pass into ExecuteSqlCommand
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            foreach (DictionaryEntry dictionaryEntry in queryParams)
            {
                sqlParams.Add(new SqlParameter(dictionaryEntry.Key.ToString(), dictionaryEntry.Value.ToString()));
            }

            return Context.Database.ExecuteSqlCommand(query, sqlParams);
        }

        /// <summary>
        /// Finds entities based on provided expression criteria.
        /// </summary>
        /// <param name="criteria" type="Expression"></param>
        /// <returns>IEnumerable&lt;TEntity&gt;</returns>
        public IEnumerable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return Context.Set<TEntity>().Where(criteria);
        }

        /// <summary>
        /// Gets a collection of all the entities
        /// </summary>
        /// <returns>IEnumerable&lt;TEntity&gt;</returns>
        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return Context.Set<TEntity>().AsEnumerable();
        }

        /// <summary>
        /// Gets the entity by ID provided
        /// </summary>
        /// <param name="id" type="object"></param>
        /// <returns>TEntity</returns>
        public TEntity GetByID<TEntity>(object id) where TEntity : class
        {
            return Context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Returns all errors associated with the current DBContext instance
        /// </summary>
        /// <returns>IEnumerable&lt;DbEntityValidationResult&gt;</returns>
        public IEnumerable<DbEntityValidationResult> GetDbEntityValidationErrors()
        {
            return Context.GetValidationErrors();
        }

        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <returns>IQueryable&lt;TEntity&gt;</returns>
        public IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class
        {
            string entityName = GetEntityName<TEntity>();
            return ((IObjectContextAdapter)Context).ObjectContext.CreateQuery<TEntity>(entityName);
        }

        /// <summary>
        /// Gets the query
        /// </summary>        
        /// <param name="predicate" type="Expression"></param>
        /// <returns>IQueryable&lt;TEntity&gt;</returns>
        public IQueryable<TEntity> GetQuery<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        /// <summary>
        /// Updates changes of the entity provided and changes its state to 'EntityState.Modified'.
        /// SaveChanges must still be called (UoW) to save the entity to the DB.
        /// </summary>
        /// <param name="entity" type="TEntity"></param>
        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Gets the name of the entity
        /// </summary>
        /// <returns>string</returns>
        private string GetEntityName<TEntity>()
        {
            string entitySetName = ((IObjectContextAdapter)Context).ObjectContext
                .MetadataWorkspace
                .GetEntityContainer(((IObjectContextAdapter)Context).ObjectContext.DefaultContainerName,
                    DataSpace.CSpace)
                .BaseEntitySets.First(bes => bes.ElementType.Name == typeof(TEntity).Name).Name;
            return string.Format("{0}.{1}", ((IObjectContextAdapter)Context).ObjectContext.DefaultContainerName,
                entitySetName);
        }
    }
}
