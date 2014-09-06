using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using BowlingSPAService.Model.DomainModels;
using BowlingSPAService.Model.EntityModels;
using BowlingSPAService.Repository.RepoTransactions;

namespace BowlingSPAService.WebAPI.Controllers.api
{
    [RoutePrefix("BowlerStandings")]
    public class BowlerStandingsController : ApiController
    {

        private readonly IUnitOfWork unitOfWork;

        public BowlerStandingsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Gets the stats for the individual bowler based on the team provided.
        /// </summary>
        /// <param name="bowlerId" type="int"></param>
        /// <param name="teamId" type="int"></param>
        /// <returns>BowlerStats</returns>
        [Route("")]
        public BowlerStats Get(int bowlerId, int teamId)
        {

            //Get all of the scores for the bowler on the team specified
            var bowlerScores = this.unitOfWork.Repository.GetQuery<Score>(x => x.BowlerId == bowlerId  && x.TeamId == teamId)
                                                                        .Include(x => x.Team)
                                                                        .Include(x => x.Bowler).ToList();

            //Calculate the stats for
            var bowler = new Bowler();
            return bowler.CalculateBowlerStats(bowlerScores);
        }
    }
    
}