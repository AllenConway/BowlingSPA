using System;
using System.Data.Entity;
using BowlingSPAService.Repository.Repositories;

namespace BowlingSPAService.Repository.RepoTransactions
{
    /// <summary>
    /// The unit of work class serves one purpose: to make sure that when you use multiple repositories, they share a single database context. 
    /// That way, when a unit of work is complete, call the SaveChanges method on that instance of the context and all related changes will be coordinated. 
    /// All this class needs is a Save method and a property for each repository. Each repository property returns a repository instance that has been instantiated 
    /// using the same database context instance as the other repository instances.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext dbContext;

        /// <summary>
        /// Default constructor taking in an injected instance of Repository and
        /// DBContext for persistence via Entity Framework.
        /// </summary>
        /// <param name="repository" type="IRepository"></param>
        /// <param name="dbContext" type="DbContext"></param>
        public UnitOfWork(DbContext dbContext, IRepository repository)
        {
            this.dbContext = dbContext;
            Repository = repository;
        }

        /// <summary>
        /// Entity Framework DbContext used for UoW
        /// </summary>
        public DbContext DbContext
        {
            get { return dbContext; }
        }

        /// <summary>
        /// Returns repository instance that has been previously or newly instantiated.
        /// </summary>
        public IRepository Repository { get; set; }


        /// <summary>
        /// Persists/Saves all changes to the DB on the current EF context.
        /// </summary>
        public void Save()
        {
            dbContext.SaveChanges();
        }

        #region " IDisposable Implementation "

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes off the managed and unmanaged resources used.
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            if (disposed)
                return;
            dbContext.Dispose();
            disposed = true;
        }

        private bool disposed;
        #endregion

    }
}
