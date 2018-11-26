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
        private readonly IMatchService _matchService;
        private readonly ILeagueRepository _leagueRepository;
        private readonly IMapper _mapper;

        public LeagueService(ILeagueRepository leagueRepository, IMapper mapper, IMatchService matchService)
        {
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

        public ResponseDto<MatchScheduleDto> GenerateMatchSchedule(int leagueId)
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
                    for(int j =0; j < league.Quantity-1; j++)
                    {
                        if (j < (league.Quantity-1)/2)
                        {
                            queue.Add(teams[j].Id, teams[teams.Count - j-2].Id);
                        }
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
                var matches = new List<MatchDto>();
                foreach(var match in queue)
                {
                    var hostTeam = teams.FirstOrDefault(t => t.Id == match.Key);
                    var awayTeam = teams.FirstOrDefault(t => t.Id == match.Value);

                    matches.Add(new MatchDto
                    {
                        Away = _mapper.Map<TeamLessDetailsDto>(awayTeam),
                        Host = _mapper.Map<TeamLessDetailsDto>(hostTeam),
                        Date = DateTime.Now.AddDays(1 * schedule.IndexOf(queue)),
                        Round = schedule.IndexOf(queue),
                        League = _mapper.Map<LeagueLessDetailsDto>(league)
                    });
                }

                response.Object.Queue.Add(new MatchQueueDto
                {
                    Round = schedule.IndexOf(queue),
                    Matches = matches
                });
            }

            return response;
        }
    }
}
