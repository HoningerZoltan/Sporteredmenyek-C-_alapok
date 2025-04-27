using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.Core.Models
{
    public record BasketballMatch : Match
    {
        public override int PeriodsNumber { get; } = 4;

        public TeamsIntValuePair Fouls { get; init; }
        public TeamsIntValuePair ThreePointMade { get; init; }

        public BasketballMatch(
            string homeTeam,
            string awayTeam,
            DateTime startTime,
            string location,
            TeamsIntValuePair result,
            List<TeamsIntValuePair> periodResults,
            TeamsIntValuePair fouls,
            TeamsIntValuePair threePointMade
        ) : base(homeTeam, awayTeam, startTime, location, result)
        {
            PeriodResults = periodResults;
            Fouls = fouls;
            ThreePointMade = threePointMade;
        }

        public override void Print()
        {
            Console.WriteLine("BasketBall");
        }
    }
}
