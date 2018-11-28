using AutoMapper;
using Football_League.Data.Interfaces;
using Football_League.Models.BindingModels;
using Football_League.Models.Domain;
using Football_League.Models.Dto;
using Football_League.Models.Dto.MatchSchedule;
using Football_League.Models.Dto.TableDto;
using Football_League.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Services.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMatchService _matchService;
        private readonly ILeagueRepository _leagueRepository;
        private readonly IMapper _mapper;

        public LeagueService(ILeagueRepository leagueRepository, IMapper mapper, IMatchService matchService, IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
            _matchService = matchService;
            _leagueRepository = leagueRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<BaseModelDto>> InsertLeagueAsync(AddLeagueBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var league = _leagueRepository.GetByName(model.Name);
            if (league != null)
            {
                response.Errors.Add(ServiceErrors.LEAGUE_ALREADY_EXISTS);
                return response;
            }
            league = new League()
            {
                Name = model.Name,
                Quantity = model.Quantity,
                Teams = new List<Team>()
            };
            await _leagueRepository.InsertAsync(league);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> EditLeagueAsync(int leagueId, EditLeagueBindingModel model)
        {
            var resposne = new ResponseDto<BaseModelDto>();

            var league = _leagueRepository.GetById(leagueId);
            if(league == null)
            {
                resposne.Errors.Add(ServiceErrors.LEAGUE_DOESNT_EXIST);
                return resposne;
            }

            await _leagueRepository.EditAsync(league);

            return resposne;
        }

        public ResponseDto<LeagueDto> GetLeague(int leagueId)
        {
            var response = new ResponseDto<LeagueDto>()
            {
                Object = new LeagueDto()
            };

            var league = _leagueRepository.GetById(leagueId);
            if(league == null)
            {
                response.Errors.Add(ServiceErrors.LEAGUE_DOESNT_EXIST);
                return response;
            }

            response.Object = _mapper.Map<LeagueDto>(league);

            return response;
        }

        public ResponseDto<LeaguesDto> GetAllLeagues()
        {
            var response = new ResponseDto<LeaguesDto>
            {
                Object = new LeaguesDto()
            };

            var leagues = _leagueRepository.GetAll().ToList();
            response.Object.Leagues = _mapper.Map<List<LeagueDto>>(leagues);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> DeleteLeague(int leagueId)
        {
            var response = new ResponseDto<BaseModelDto>();

            var league = _leagueRepository.GetById(leagueId);
            if(league == null)
            {
                response.Errors.Add(ServiceErrors.LEAGUE_DOESNT_EXIST);
                return response;
            }

            await _leagueRepository.DeleteAsync(league);

            return response;
        }

        public async Task<ResponseDto<MatchScheduleDto>> GenerateMatchSchedule(int leagueId)
        {
            var response = new ResponseDto<MatchScheduleDto>
            {
                Object = new MatchScheduleDto()
            };

            var league = _leagueRepository.GetById(leagueId);
            if (league == null)
            {
                response.Errors.Add(ServiceErrors.LEAGUE_DOESNT_EXIST);
                return response;
            }

            if(league.Teams.Count < league.Quantity)
            {
                response.Errors.Add(ServiceErrors.LEAGUE_NOT_AVAILABLE_NUMBER_OF_TEAMS);
                return response;
            }

            var schedule = new List<Dictionary<int, int>>();
            var teams = league.Teams.ToList();
            if (league.Quantity % 2 != 0)
            {
                for(int i = 0; i < league.Quantity; i++)
                {
                    var queue = new Dictionary<int,int>();
                    var popped = teams[0];
                    if(i == 0)
                    {
                        popped = teams[teams.Count - 1];
                        
                    }
                    var j = 0;
                    while (j < (league.Quantity-1)/2)
                    {
                        queue.Add(teams[j].Id, teams[teams.Count - j-2].Id);
                        j++;
                    }
                    if(i == 0)
                    {
                        teams.RemoveAt(teams.Count - 1);
                        teams.Add(popped);
                    }                       
                    popped = teams[0];
                    teams.RemoveAt(0);
                    teams.Add(popped);
                    schedule.Add(queue);
                }                
            } else
            {
                for(int i = 0; i < league.Quantity - 1; i++)
                {
                    var queue = new Dictionary<int, int>();
                    var popped = teams[0];
                    var j = 0;
                    while (j < (league.Quantity / 2))
                    {
                        queue.Add(teams[j].Id, teams[teams.Count - j + i - 2].Id);

                        j++;
                    }
                    teams.RemoveAt(0);
                    teams.Add(popped);
                    schedule.Add(queue);
                }
            }

            var rematches = new List<Dictionary<int, int>>();

            foreach(var queue in schedule)
            {

                var reverseQueue = new Dictionary<int, int>();
                foreach(var match in queue)
                {
                    reverseQueue.Add(match.Value, match.Key);
                }
                rematches.Add(reverseQueue);
            }

            schedule = schedule.Concat(rematches).ToList();

            foreach (var queue in schedule)
            {
                var matchesDto = new List<MatchDto>();
                foreach(var match in queue)
                {
                    var hostTeam = teams.FirstOrDefault(t => t.Id == match.Key);
                    var awayTeam = teams.FirstOrDefault(t => t.Id == match.Value);

                    var matchPlayers = new List<MatchPlayer>();
                    var players = hostTeam.Players.Concat(awayTeam.Players).ToList();

                    players.ForEach(player =>
                    {
                        var matchPlayer = new MatchPlayer
                        {
                            PlayerId = player.Id,
                            Player = player,
                            EntryMinute = 0,
                            DescentMinute = 90
                        };
                        matchPlayers.Add(matchPlayer);
                    }
                    );

                    matchesDto.Add(new MatchDto
                    {
                        Away = _mapper.Map<TeamLessDetailsDto>(awayTeam),
                        Host = _mapper.Map<TeamLessDetailsDto>(hostTeam),
                        Date = DateTime.Now.AddDays(1 * schedule.IndexOf(queue)),
                        Round = schedule.IndexOf(queue),
                        League = _mapper.Map<LeagueLessDetailsDto>(league),
                        AwayScore = -1,
                        HostScore = -1
                    });

                    await _matchRepository.InsertAsync(new Match
                    {
                        Away = awayTeam,
                        AwayScore = -1,
                        Date = DateTime.Now.AddDays(1 * schedule.IndexOf(queue)),
                        Round = schedule.IndexOf(queue),
                        Host = hostTeam,
                        HostScore = -1,
                        League = league,
                        MatchPlayers = matchPlayers
                    });
                }

                response.Object.Queue.Add(new MatchQueueDto
                {
                    Round = schedule.IndexOf(queue),
                    Matches = matchesDto
                });
            }

            return response;
        }
    }
}
