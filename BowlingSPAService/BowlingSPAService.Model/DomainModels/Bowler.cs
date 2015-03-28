using System.Collections.Generic;
using System.Linq;
using BowlingSPAService.Model.DomainModels;

namespace BowlingSPAService.Model.EntityModels
{
    public partial class Bowler
    {

        //Read-only properties will not be serialized, so must include the 'set' as well
        private string fullName;
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
            set { fullName = value; }
        }

        /// <summary>
        /// Calculates bowler stats 
        /// </summary>
        /// <param name="bowlerScores"></param>
        /// <returns></returns>
        public BowlerStats CalculateBowlerStats(IList<Score> bowlerScores)
        {
            BowlerStats bowlerStats = new BowlerStats();

            if (bowlerScores == null || !bowlerScores.Any())
                return bowlerStats;
           
            var average = bowlerScores.Average(x => x.Pins);
            if (average != null)
                bowlerStats.Average = (double)average;
            bowlerStats.HighGame = bowlerScores.OrderByDescending(x => x.Pins).Select(y => y.Pins).FirstOrDefault();
            bowlerStats.BowlerName = bowlerScores.First().Bowler.FullName;
            bowlerStats.TeamName = bowlerScores.First().Team.Name;

            return bowlerStats;

        }

    }
}
