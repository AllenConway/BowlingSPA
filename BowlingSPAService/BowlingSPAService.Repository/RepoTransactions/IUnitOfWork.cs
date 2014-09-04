using System;
using System.Data.Entity;
using BowlingSPAService.Repository.Repositories;

namespace BowlingSPAService.Repository.RepoTransactions
{
    /// <summary>
    /// UoW Interface defines methods that makes sure when multiple repositories are used, they share a single database context.
    /// This Interface also defines instances of the repository instances for the UoW. The generic IRepository instance
    /// should cover most needs for querying, shaping, and hydrating business objects, and additional repositories
    /// should only be added if there is something not covered already.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {

        DbContext DbContext { get; }

        IRepository Repository { get; }
      
        void Save();

    }
}
