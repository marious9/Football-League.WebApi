using AutoMapper;
using Football_League.Data.Interfaces;
using Football_League.Models.BindingModels;
using Football_League.Models.Domain;
using Football_League.Models.Dto;
using Football_League.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Football_League.Services.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IMatchPlayerRepository _matchPlayerRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly ILeagueRepository _leagueRepository;
        private readonly IMapper _mapper;
        private readonly IStatisticRepository _statisticRepository;

        public StatisticService(IMatchPlayerRepository matchPlayerRepository, IPlayerRepository playerRepository,IMatchRepository matchRepository, ILeagueRepository leagueRepository, IMapper mapper, IStatisticRepository statisticRepository)
        {
            _matchPlayerRepository = matchPlayerRepository;
            _playerRepository = playerRepository;
            _matchRepository = matchRepository;
            _leagueRepository = leagueRepository;
            _mapper = mapper;
            _statisticRepository = statisticRepository;
        }

        public ResponseDto<LeagueRankingDto> GetLeagueStatistics(int leagueId)
        {
            var response = new ResponseDto<LeagueRankingDto>
            {
                Object = new LeagueRankingDto()
            };

            var league = _leagueRepository.GetById(leagueId);
            if(league == null)
            {
                response.Errors.Add(ServiceErrors.LEAGUE_DOESNT_EXIST);
                return response;
            }

            var players = new List<PlayerDtoLessDetails>();

            league.Teams.ToList().ForEach(team =>
                team.Players.ToList().ForEach(player =>
                    players.Add(new PlayerDtoLessDetails
                        {
                            BirthDate = player.BirthDate,
                            Firstname = player.Firstname,
                            Id = player.Id,
                            Lastname = player.Lastname,
                            TeamName = team.Name
                        }
                    )
                )
            );            

            players.ForEach(player =>
            {
                response.Object.Players.Add(
                    new PlayerStatisticsDto
                    {
                        Player = player,
                        Goals = CountStatistics(player.Id)[Models.Enums.Action.Goal],
                        Assists = CountStatistics(player.Id)[Models.Enums.Action.Assist],
                        YellowCards = CountStatistics(player.Id)[Models.Enums.Action.YellowCard],
                        RedCards = CountStatistics(player.Id)[Models.Enums.Action.RedCard],
                        MissedPenalties = CountStatistics(player.Id)[Models.Enums.Action.MissedPenalty]                        
                    }
                );
            });

            return response;
        }

        private Dictionary<Models.Enums.Action,int> CountStatistics(int playerId)
        {
            var statistics = _statisticRepository.GetAll().Where(s => s.MatchPlayer.PlayerId == playerId).ToList();

            var playerStatistics = new Dictionary<Models.Enums.Action, int> {
                {Models.Enums.Action.Goal, statistics.Where(s => s.Action == Models.Enums.Action.Goal).Count() },
                {Models.Enums.Action.Assist, statistics.Where(s => s.Action == Models.Enums.Action.Assist).Count() },
                {Models.Enums.Action.YellowCard, statistics.Where(s => s.Action == Models.Enums.Action.YellowCard).Count() },
                {Models.Enums.Action.RedCard, statistics.Where(s => s.Action == Models.Enums.Action.RedCard).Count() },
                {Models.Enums.Action.MissedPenalty, statistics.Where(s => s.Action == Models.Enums.Action.MissedPenalty).Count() }
            };

            return playerStatistics;
        }

        public ResponseDto<MatchStatisticsDto> GetMatchStatistics(int matchId)
        {
            var response = new ResponseDto<MatchStatisticsDto>
            {
                Object = new MatchStatisticsDto()
            };

            var match = _matchRepository.GetById(matchId);
            if(match == null)
            {
                response.Errors.Add(ServiceErrors.MATCH_DOES_NOT_EXIST);
                return response;
            }

            var matchPlayers = match.MatchPlayers.ToList();
            var statistics = new List<MatchStatisticDto>();

            matchPlayers.ForEach(matchplayer =>
            {
                matchplayer.Statistics.ToList().ForEach(statistic =>
                {
                    statistics.Add(new MatchStatisticDto
                    {
                        Action = statistic.Action,
                        MatchPlayer = _mapper.Map<MatchPlayerDtoLessDetails>(matchplayer),
                        Id = statistic.Id,
                        Minute = statistic.Minute
                    });
                });
            });

            statistics = statistics.OrderBy(s => s.Minute).ToList();

            response.Object.Statistics = statistics;

            return response;
        }

        public ResponseDto<StatisticDto> GetStatistic(int statisticId)
        {
            var response = new ResponseDto<StatisticDto>();

            var statistic = _statisticRepository.GetById(statisticId);

            if(statistic == null)
            {
                response.Errors.Add(ServiceErrors.STATISTIC_DOES_NOT_EXIST);
                return response;
            }

            response.Object = _mapper.Map<StatisticDto>(statistic);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> InsertAsync(AddStatisticBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();           

            var match = _matchRepository.GetById(model.MatchId);
            if(match == null)
            {
                response.Errors.Add(ServiceErrors.MATCH_DOES_NOT_EXIST);
                return response;
            }

            var player = _playerRepository.GetById(model.PlayerId);
            if (player == null)
            {
                response.Errors.Add(ServiceErrors.PLAYER_DOESNT_EXIST);
                return response;
            }

            var matchPlayer = _matchPlayerRepository.GetById(model.MatchId, model.PlayerId);
            if(matchPlayer == null)
            {
                response.Errors.Add(ServiceErrors.MATCH_PLAYER_DOES_NOT_EXIST);
                return response;
            }

            if(ValidateMatchWithRedCardStatistic(matchPlayer, model) != String.Empty)
            {
                response.Errors.Add(ServiceErrors.STATISTIC_PLAYER_HAS_RED_CARD);
                return response;
            }

            if (!ValidateMatchWithGoalAndAssistStatistic(match, player, model))
            {
                response.Errors.Add(ServiceErrors.STATISTIC_SCORE_IS_NOT_ALLOW_TO_ADD_GOAL_ACTION);
                return response;
            }

            var statistic = new Statistic
            {
                MatchPlayer = matchPlayer,
                Minute = model.Minute,
                Action = model.Action
            };

            await _statisticRepository.InsertAsync(statistic);

            return response;
        }

        private string ValidateMatchWithRedCardStatistic(MatchPlayer matchPlayer, AddStatisticBindingModel model)
        {
            var playerHadRedCardBeforeGivenStatistic = matchPlayer.Statistics.Any(s => s.Action == Models.Enums.Action.RedCard && model.Minute > s.Minute);

            if (playerHadRedCardBeforeGivenStatistic)
            {
                return ServiceErrors.STATISTIC_PLAYER_HAS_RED_CARD;
                
            }

            var playerYellowCards = matchPlayer.Statistics.Where(s => s.Action == Models.Enums.Action.YellowCard).ToList();
            if (playerYellowCards.Count == 2)
            {

                var sortedPlayerYellowCard = playerYellowCards.OrderBy(s => s.Minute).ToList();

                var actionIsBeforeSecondYellowCard = model.Minute <= sortedPlayerYellowCard[1].Minute;

                if (!actionIsBeforeSecondYellowCard)
                {
                    return ServiceErrors.STATISTIC_PLAYER_HAS_RED_CARD;
                    
                }
            }

            return "";
        }

        private bool ValidateMatchWithGoalAndAssistStatistic(Match match, Player player, AddStatisticBindingModel model)
        {
            var statisticsGoals = new List<int> { 0, 0 };
            var statisticsAssists = new List<int> { 0, 0 };
            var isValid = true;
            foreach (var mPlayer in match.MatchPlayers)
            {
                if (mPlayer.Player.Team.Id == match.Host.Id)
                {
                    statisticsGoals[0] += mPlayer.Statistics.Where(s => s.Action == Models.Enums.Action.Goal).Count();
                    statisticsAssists[0] += mPlayer.Statistics.Where(s => s.Action == Models.Enums.Action.Assist).Count();
                }
                else
                {
                    statisticsGoals[1] += mPlayer.Statistics.Where(s => s.Action == Models.Enums.Action.Goal).Count();

                    statisticsAssists[1] += mPlayer.Statistics.Where(s => s.Action == Models.Enums.Action.Assist).Count();
                }
            }

            var playerTeamIsHost = match.Host.Id == player.Team.Id;

            var canAddGoal = false;

            if (playerTeamIsHost && (statisticsGoals[0] < match.HostScore))
            {
                canAddGoal = true;
            }
            if (!playerTeamIsHost && (statisticsGoals[1] < match.AwayScore))
            {
                canAddGoal = true;
            }

            var canAddAssist = false;

            if (playerTeamIsHost && (statisticsAssists[0] < match.HostScore))
            {
                canAddAssist = true;
            }
            if (!playerTeamIsHost && (statisticsAssists[1] < match.AwayScore))
            {
                canAddAssist = true;
            }

            if ((!canAddGoal && (model.Action == Models.Enums.Action.Goal)) || (!canAddAssist && (model.Action == Models.Enums.Action.Assist)))
            {
                isValid = false;                
            }

            return isValid;
        }

        public async Task<ResponseDto<BaseModelDto>> DeleteAsync(int statisticId)
        {
            var response = new ResponseDto<BaseModelDto>();
            var statistic = _statisticRepository.GetById(statisticId);     
            if(statistic == null)
            {
                response.Errors.Add(ServiceErrors.STATISTIC_DOES_NOT_EXIST);
                return response;
            }

            await _statisticRepository.DeleteAsync(statistic);

            return response;
        }
    }
}
