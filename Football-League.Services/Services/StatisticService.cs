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

            var action = new List<Models.Enums.Action>();

            //try
            //{
            //    var actionType = (Models.Enums.Action)Enum.Parse(typeof(Models.Enums.Action), model.Action, true);
            //    action.Add(actionType);
            //}
            //catch
            //{
            //    response.Errors.Add(ServiceErrors.STATISTIC_INVALID_ACTION);
            //    return response;
            //}
                

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

            var statistic = new Statistic
            {
                MatchPlayer = matchPlayer,
                Minute = model.Minute,
                Action = model.Action
            };

            await _statisticRepository.InsertAsync(statistic);

            return response;
        }
    }
}
