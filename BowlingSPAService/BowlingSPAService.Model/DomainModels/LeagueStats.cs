﻿namespace BowlingSPAService.Model.DomainModels
{
    public class LeagueStats
    {

        public string TeamName { get; set; }

        public int Position { get; set; }

        public int? TotalPins { get; set; }

        public int? TotalHandicap { get; set; }

        //Read-only properties will not be serialized, so must include the 'set' as well
        private int? totalPinsPlusHandicap;
        public int? TotalPinsPlusHandicap
        {
            get { return (this.TotalPins + this.TotalHandicap); }
            set { totalPinsPlusHandicap = value; }
        }
    }
}
