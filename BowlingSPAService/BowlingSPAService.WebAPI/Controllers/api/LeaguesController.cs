using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BowlingSPAService.Model.EntityModels;
using BowlingSPAService.Repository.RepoTransactions;

namespace BowlingSPAService.WebAPI.Controllers.api
{
    public class LeaguesController : ApiController
    {

        private readonly IUnitOfWork unitOfWork;

        public LeaguesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        /// <summary>
        /// Returns all of the Leagues
        /// </summary>
        /// <returns></returns>
        [Route("Leagues")]
        public IEnumerable<League> Get()
        {
            return unitOfWork.Repository.GetAll<League>();
        }

        [Route("Leagues/{id}")]
        public League Get(int id)
        {
            return this.unitOfWork.Repository.GetQuery<League>(x => x.Id == id).SingleOrDefault();
        }

    }
}