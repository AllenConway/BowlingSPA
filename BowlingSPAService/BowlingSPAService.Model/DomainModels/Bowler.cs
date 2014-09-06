using System.Collections.Generic;
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

        public BowlerStats CalculateBowlerStats(IList<Bowler> bowlers, int leagueId)
        {
            return new BowlerStats();
        }

    }
}
