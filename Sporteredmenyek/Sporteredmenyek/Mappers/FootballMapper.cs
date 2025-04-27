using Sporteredmenyek.Core.Models;
using Sporteredmenyek.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.Mappers
{
    public static class FootballMapper
    {
        public static JsonFootballDto ToDto(this FootballMatch match) {

            List<int> periodResultsHome = new List<int>();
            List<int> periodResultsAway = new List<int>();
            foreach (var result in match.PeriodResults)
            {
                periodResultsHome.Add(result.Home);
                periodResultsAway.Add(result.Away);
            }
            return new JsonFootballDto
            {
                HomeTeam = match.HomeTeam,
                AwayTeam = match.AwayTeam,
                StartTime = match.StartTime,
                Location = match.Location,
                ResultHome = match.Result.Home,
                ResultAway = match.Result.Away,
                YellowCardsHome = match.YellowCards.Home,
                YellowCardAway = match.YellowCards.Away,
                RedCardsHome = match.RedCards.Home,
                RedCardAway = match.RedCards.Away,
                CornersHome = match.Corners.Home,
                CornersAway = match.Corners.Away,
                PeriodResultsHome = periodResultsHome,
                PeriodResultsAway = periodResultsAway

            };
        }
        public static FootballMatch ToDomainObject(this JsonFootballDto dto) 
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
            TeamsIntValuePair yellowCards = new TeamsIntValuePair();
            result.Home = dto.YellowCardsHome;
            result.Away = dto.YellowCardAway;
            TeamsIntValuePair redCards = new TeamsIntValuePair();
            result.Home = dto.RedCardsHome;
            result.Away = dto.RedCardAway;
            TeamsIntValuePair corners = new TeamsIntValuePair();
            result.Home = dto.CornersHome;
            result.Away = dto.CornersAway;

            return new FootballMatch
            (
                dto.HomeTeam,
                dto.AwayTeam,
                dto.StartTime,
                dto.Location,
                periodResults,
                result,
                redCards,
                yellowCards,
                corners
            );
        }
    }
}
