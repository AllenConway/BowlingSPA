using System;

namespace BowlingSPAService.Model.DomainModels
{
    public class BowlerStats
    {
        private double average;
        public double Average
        {
            get { return Math.Round(average, 2, MidpointRounding.AwayFromZero); }
            
            set { average = value; }
        }

        public string BowlerName { get; set; }

        public int? HighGame { get; set; }

        public string TeamName { get; set; }

    }
}
