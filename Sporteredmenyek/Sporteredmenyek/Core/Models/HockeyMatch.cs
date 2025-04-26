using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.Core.Models
{
    public record HockeyMatch : Match
    {
        public override int PeriodsNumber { get; } = 3;

        public TeamsIntValuePair PenaltyMinutes { get; init; }
        public TeamsIntValuePair ShotsOnGoal { get; init; }
        public TeamsIntValuePair Saves { get; init; }


        public HockeyMatch(
            Team homeTeam, 
            Team awayTeam, 
            DateTime start_time, 
            string location,
            List<TeamsIntValuePair> periodResults,
            TeamsIntValuePair result,
            TeamsIntValuePair penaltyMinutes,
            TeamsIntValuePair shotsOnGoal, 
            TeamsIntValuePair saves
        )  : base(homeTeam, awayTeam, start_time, location, result)
        {
            PeriodResults = periodResults;
            PenaltyMinutes = penaltyMinutes;
            Saves = saves;
            ShotsOnGoal = shotsOnGoal;
        }
        public override void Print()
        {
            Console.WriteLine("IceHockey");
        }


    }
}
