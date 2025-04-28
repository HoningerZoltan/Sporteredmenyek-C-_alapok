using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace Sporteredmenyek.Core.Models
{
    public record HockeyMatch : Match
    {
        public override int PeriodsNumber { get; } = 3;

        public TeamsIntValuePair PenaltyMinutes { get; init; }
        public TeamsIntValuePair ShotsOnGoal { get; init; }


        public HockeyMatch(
            string homeTeam, 
            string awayTeam, 
            DateTime start_time, 
            string location,
            List<TeamsIntValuePair> periodResults,
            TeamsIntValuePair result,
            TeamsIntValuePair penaltyMinutes,
            TeamsIntValuePair shotsOnGoal
        )  : base(homeTeam, awayTeam, start_time, location, result)
        {
            PeriodResults = periodResults;
            PenaltyMinutes = penaltyMinutes;
            ShotsOnGoal = shotsOnGoal;
        }
        public override void Print()
        {

        }


    }
}
