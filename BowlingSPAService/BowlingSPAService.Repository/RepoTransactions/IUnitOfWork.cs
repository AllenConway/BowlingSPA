using System;
using System.Data.Entity;
using BowlingSPAService.Repository.Repositories;

namespace BowlingSPAService.Repository.RepoTransactions
{
    /// <summary>
    /// The UoW Interface (and resulting implementations) serves one purpose: to make sure that when you use multiple repositories, they share a single database context
    /// This Interface should contain an instance of each repository type being used by the UoW as well.
    /// </summary>
    /// <remarks>The generic IRepository instance here should cover most needs for querying, shaping, and hydrating business objects, 
    /// and additional repositories should only be added if there is something not covered already.
    /// Additional information: http://bit.ly/1dbKtkL </remarks>
    public interface IUnitOfWork : IDisposable
    {

        DbContext DbContext { get; }

        IRepository Repository { get; }
      
        void Save();

    }
}
