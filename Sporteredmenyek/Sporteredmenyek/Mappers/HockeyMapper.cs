using Sporteredmenyek.Core.Models;
using Sporteredmenyek.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.Mappers
{
    public static class HockeyMapper
    {
        public static JsonHockeyDto ToDto(this HockeyMatch match)
        {

            List<int> periodResultsHome = new List<int>();
            List<int> periodResultsAway = new List<int>();
            foreach (var result in match.PeriodResults)
            {
                periodResultsHome.Add(result.Home);
                periodResultsAway.Add(result.Away);
            }
            return new JsonHockeyDto
            {
                HomeTeam = match.HomeTeam,
                AwayTeam = match.AwayTeam,
                StartTime = match.StartTime,
                Location = match.Location,
                ResultHome = match.Result.Home,
                ResultAway = match.Result.Away,
                PenaltyMinutesHome = match.PenaltyMinutes.Home,
                PenaltyMinutesAway = match.PenaltyMinutes.Away,
                ShotsOnGoalHome = match.ShotsOnGoal.Home,
                ShotsOnGoalAway = match.ShotsOnGoal.Away,
                PeriodResultsHome = periodResultsHome,
                PeriodResultsAway = periodResultsAway

            };
        }
        public static HockeyMatch ToDomainObject(this JsonHockeyDto dto)
        {
            TeamsIntValuePair result = new TeamsIntValuePair();
            result.Home = dto.ResultHome;
            result.Away = dto.ResultAway;
            List<TeamsIntValuePair> periodResults = new List<TeamsIntValuePair>();
            for (int i = 0; i < dto.PeriodResultsAway.Count; i++)
            {
                TeamsIntValuePair pair = new TeamsIntValuePair();
                pair.Home = dto.PeriodResultsHome[i];
                pair.Away = dto.PeriodResultsAway[i];
                periodResults.Add(pair);
            }
            TeamsIntValuePair penaltyMinutes = new TeamsIntValuePair();
            result.Home = dto.PenaltyMinutesHome;
            result.Away = dto.PenaltyMinutesAway;
            TeamsIntValuePair shotsOnGoal = new TeamsIntValuePair();
            result.Home = dto.ShotsOnGoalHome;
            result.Away = dto.ShotsOnGoalAway;


            return new HockeyMatch
            (
                dto.HomeTeam,
                dto.AwayTeam,
                dto.StartTime,
                dto.Location,
                periodResults,
                result,
                penaltyMinutes,
                shotsOnGoal
            );
        }
    }
}
