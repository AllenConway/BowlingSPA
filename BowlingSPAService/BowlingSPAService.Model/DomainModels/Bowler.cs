using System.Collections.Generic;
using BowlingSPAService.Model.DomainModels;

namespace BowlingSPAService.Model.EntityModels
{
    public partial class Bowler
    {

        public BowlerStats CalculateBowlerStats(IList<Bowler> bowlers, int leagueId)
        {
            return new BowlerStats();
        }

    }
}
