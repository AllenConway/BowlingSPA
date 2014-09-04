using System.Collections.Generic;
using System.Linq;
using BowlingSPAService.Model.DomainModels;

namespace BowlingSPAService.Model.EntityModels
{
    public partial class League
    {

        public IEnumerable<LeagueStats> CalculateLeagueStats(IList<Team> teams)
        {

            IList<LeagueStats> leagueStats = new List<LeagueStats>();
            foreach (var team in teams)
            {
                var stats = new LeagueStats();
                stats.TeamName = team.Name;
                stats.TotalPins = team.Scores.Sum(x => x.Pins);
                stats.TotalHandicap = team.Scores.Sum(x => x.Handicap);
                leagueStats.Add(stats);
            }

            var leagueStatsByPins = leagueStats.OrderByDescending(x => x.TotalPins).ToList();
            int position = 1;
            foreach (var team in leagueStatsByPins)
            {
                team.Position = position;
                position++;
            }


            return leagueStats.OrderBy(x => x.Position);
        }
    }
}
