﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using BowlingSPAService.Model.DomainModels;
using BowlingSPAService.Model.EntityModels;
using BowlingSPAService.Repository.RepoTransactions;

namespace BowlingSPAService.WebAPI.Controllers.api
{
    [RoutePrefix("LeagueStandings")]
    public class LeagueStandingsController : ApiController
    {

        private readonly IUnitOfWork unitOfWork;

        public LeagueStandingsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Gets all of the teams for the league ID provided, and returns the league standings 
        /// </summary>
        /// <param name="leagueId"></param>
        /// <returns></returns>
        [Route("{leagueId}")]
        public IEnumerable<LeagueStats> Get(int leagueId)
        {
            //Get all of the teams for the league ID provided, so we can calculate the 
            var teams = this.unitOfWork.Repository.GetQuery<Team>(x => x.LeagueId == leagueId)
                                                                        .Include(x => x.Scores).ToList();

            //Calculate the league stats
            var league = new League();
            return league.CalculateLeagueStats(teams);
        }
    }
}