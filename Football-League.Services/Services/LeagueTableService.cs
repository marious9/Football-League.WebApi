using Football_League.Models.Dto;
using Football_League.Models.Dto.TableDto;
using Football_League.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Football_League.Services.Services
{
    public class LeagueTableService : ILeagueTableService
    {
        private readonly IMatchService _matchService;
        private readonly ILeagueService _leagueService;

        public LeagueTableService(IMatchService matchService, ILeagueService leagueService)
        {
            _leagueService = leagueService;
            _matchService = matchService;
        }

        public ResponseDto<LeagueTableDto> GetLeagueTable(int leagueId)
        {
            var response = new ResponseDto<LeagueTableDto>()
            {
                Object = new LeagueTableDto()
            };

            var getMatchesrequest = _matchService.GetMatchesFromLeague(leagueId);
            if (getMatchesrequest.ErrorOccurred)
            {
                response.Errors = getMatchesrequest.Errors;
                return response;
            }

            var matches = getMatchesrequest.Object.Matches;

            var getTeamsrequest = _leagueService.GetLeague(leagueId);
            if (getTeamsrequest.ErrorOccurred)
            {
                response.Errors = getTeamsrequest.Errors;
                return response;
            }

            var teams = getTeamsrequest.Object.Teams;

            teams.ForEach(team =>
            {

                var teamMatchesHost = matches.Where(m => m.Host.Id == team.Id);
                var teamMatchesAway = matches.Where(m => m.Away.Id == team.Id);

                var scoredGoals = CountScoredGoals(teamMatchesHost, teamMatchesAway);
                var lostGoals = CountLostGoals(teamMatchesHost, teamMatchesAway);
                var tableRow = new LeagueTableRowDto
                {
                    TeamId = team.Id,
                    Name = team.Name,
                    MatchesPlayed = teamMatchesHost.Count() + teamMatchesAway.Count(),
                    MatchesWon = CountWins(teamMatchesHost, teamMatchesAway),
                    MatchesDrawn = CountDraws(teamMatchesHost, teamMatchesAway),
                    MatchesLost = CountDefeats(teamMatchesHost, teamMatchesAway),
                    Points = CountPoints(teamMatchesHost, teamMatchesAway),
                    GoalsScored = scoredGoals,
                    GoalsLost = lostGoals,
                    GoalsBilans = scoredGoals - lostGoals
                };
                response.Object.Teams.Add(tableRow);
            });

            response.Object.Teams = response.Object.Teams
                                                   .OrderByDescending(t => t.Points)
                                                   .ThenByDescending(t => t.GoalsBilans)
                                                   .ThenBy(t=> t.Name).ToList();

            return response;
        }

        private int CountPoints(IEnumerable<MatchDto> teamMatchesHost, IEnumerable<MatchDto> teamMatchesAway)
        {
            return 3*CountWins(teamMatchesHost,teamMatchesAway) + CountDraws(teamMatchesHost, teamMatchesAway);
        }

        private int CountWins(IEnumerable<MatchDto> teamMatchesHost, IEnumerable<MatchDto> teamMatchesAway)
        {
            var hostWins = teamMatchesHost.Where(m => m.HostScore > m.AwayScore).Count();
            var awayWins = teamMatchesAway.Where(m => m.HostScore < m.AwayScore).Count();

            return hostWins + awayWins;
        }

        private int CountDraws(IEnumerable<MatchDto> teamMatchesHost, IEnumerable<MatchDto> teamMatchesAway)
        {
            var hostDraws = teamMatchesHost.Where(m => m.HostScore == m.AwayScore).Count();
            var awayDraws = teamMatchesAway.Where(m => m.HostScore == m.AwayScore).Count();

            return hostDraws + awayDraws;

        }

        private int CountDefeats(IEnumerable<MatchDto> teamMatchesHost, IEnumerable<MatchDto> teamMatchesAway)
        {
            var hostLooses = teamMatchesHost.Where(m => m.HostScore < m.AwayScore).Count();
            var awayLooses = teamMatchesAway.Where(m => m.HostScore > m.AwayScore).Count();

            return hostLooses + awayLooses;
        }

        private int CountScoredGoals(IEnumerable<MatchDto> teamMatchesHost, IEnumerable<MatchDto> teamMatchesAway)
        {
            var scoredAsHost = teamMatchesHost.Sum(m => m.HostScore);
            var scoredAsAway = teamMatchesAway.Sum(m => m.AwayScore);

            return scoredAsHost + scoredAsAway;
        }

        private int CountLostGoals(IEnumerable<MatchDto> teamMatchesHost, IEnumerable<MatchDto> teamMatchesAway)
        {
            var lostAsHost = teamMatchesHost.Sum(m => m.AwayScore);
            var lostAsAway = teamMatchesAway.Sum(m => m.HostScore);

            return lostAsHost + lostAsAway;
        }
    }
}
