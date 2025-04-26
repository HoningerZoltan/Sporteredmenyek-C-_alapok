using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.Core.Models
{
    public record FootballMatch : Match
    {
        public override int PeriodsNumber { get; } = 2;

        public TeamsIntValuePair RedCards { get; init; }
        public TeamsIntValuePair YellowCards { get; init; }
        public TeamsIntValuePair Corners { get; init; }
        public FootballMatch(
            Team homeTeam,
            Team awayTeam, 
            DateTime start_time,
            string location,
             List<TeamsIntValuePair> periodResults,
            TeamsIntValuePair result, 
            TeamsIntValuePair redCards, 
            TeamsIntValuePair yellowCards, 
            TeamsIntValuePair corners
        ) : base(homeTeam, awayTeam, start_time, location, result)
        {
            PeriodResults = periodResults;
            RedCards = redCards;
            YellowCards = yellowCards;
            Corners = corners;
        }
        public override void Print()
        {
            Console.WriteLine("Football");
        }

    }
}
