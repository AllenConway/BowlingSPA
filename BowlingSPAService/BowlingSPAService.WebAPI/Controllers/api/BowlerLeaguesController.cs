using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BowlingSPAService.Model.EntityModels;
using BowlingSPAService.Repository.RepoTransactions;

namespace BowlingSPAService.WebAPI.Controllers.api
{
    [RoutePrefix("BowlerLeagues")]
    public class BowlerLeaguesController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public BowlerLeaguesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Returns a collection of team data that match the bowlerId value provided 
        /// </summary>
        /// <param name="bowlerId" type="int"></param>
        /// <returns>IEnumerable&lt;Team&gt;</returns>
        [Route("{bowlerId}")]
        public IEnumerable<Team> Get(int bowlerId)
        {
            return this.unitOfWork.Repository.GetQuery<Team>(x => x.Scores.Any(y => y.BowlerId == bowlerId)).ToList();            
        }
    }
}