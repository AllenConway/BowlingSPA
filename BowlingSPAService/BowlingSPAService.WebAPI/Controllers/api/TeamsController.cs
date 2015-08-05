using System.Collections.Generic;
using System.Web.Http;
using BowlingSPAService.Model.EntityModels;
using BowlingSPAService.Repository.RepoTransactions;

namespace BowlingSPAService.WebAPI.Controllers.api
{
    [RoutePrefix("Teams")]
    public class TeamsController : ApiController
    {

        private readonly IUnitOfWork unitOfWork;

        public TeamsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Returns all of the Leagues
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public IEnumerable<Team> Get()
        {
            return unitOfWork.Repository.GetAll<Team>();
        }

        [Route("{leagueId}")]
        public IEnumerable<Team> Get(int leagueId)
        {
            return this.unitOfWork.Repository.GetQuery<Team>(x => x.LeagueId == leagueId);
        }
    }
}