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

            var teams = league.Teams.ToList();

            var teamsIds = new List<int>();

            teams.ForEach(team => teamsIds.Add(team.Id));

            var roundRobin = GenerateRoundRobin(teamsIds.Count);

            var robinSchedule = new List<Dictionary<int, int>>();            

            for(var round = 0; round <= roundRobin.GetUpperBound(1); round++)
            {
                var queueRobin = new Dictionary<int, int>();
                for (var team = 0; team < teamsIds.Count; team++)
                {
                    if (roundRobin[team, round] == BYE)
                    {
                        queueRobin.Add(team, BYE);
                    }
                    else if (team < roundRobin[team, round])
                    {
                        queueRobin.Add(team, roundRobin[team,round]);
                    }
                }
                robinSchedule.Add(queueRobin);
            }
            var transSchedule = new List<Dictionary<int, int>>();
            
            foreach (var robinRound in robinSchedule)
            {
                var transQueue = new Dictionary<int, int>();
                foreach (var robinMatch in robinRound)
                {
                    if(!(robinMatch.Key == -1 || robinMatch.Value == -1))
                        transQueue.Add(teamsIds[robinMatch.Key], teamsIds[robinMatch.Value]);
                }
                transSchedule.Add(transQueue);
            }                   

            var rematchesSchedule = new List<Dictionary<int, int>>();

            foreach(var queue in transSchedule)
            {

                var reverseQueue = new Dictionary<int, int>();
                foreach(var match in queue)
                {
                    reverseQueue.Add(match.Value, match.Key);
                }
                rematchesSchedule.Add(reverseQueue);
            }

            var schedule = transSchedule.Concat(rematchesSchedule).ToList();

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
                        Date = DateTime.Now.AddDays((schedule.IndexOf(queue) + 1) * 7),
                        Round = schedule.IndexOf(queue),
                        League = _mapper.Map<LeagueLessDetailsDto>(league),
                        AwayScore = -1,
                        HostScore = -1
                    });

                    //await _matchRepository.InsertAsync(new Match
                    //{
                    //    Away = awayTeam,
                    //    AwayScore = -1,
                    //    Date = DateTime.Now.AddDays((schedule.IndexOf(queue)+1)*7),
                    //    Round = schedule.IndexOf(queue),
                    //    Host = hostTeam,
                    //    HostScore = -1,
                    //    League = league,
                    //    MatchPlayers = matchPlayers
                    //});
                }

                response.Object.Queue.Add(new MatchQueueDto
                {
                    Round = schedule.IndexOf(queue),
                    Matches = matchesDto
                });
            }

            return response;
        }

        private const int BYE = -1;

        private int[,] GenerateRoundRobinOdd(int num_teams)
        {
            int n2 = (int)((num_teams - 1) / 2);
            int[,] results = new int[num_teams, num_teams];

            // Initialize the list of teams.
            int[] teams = new int[num_teams];
            int[] teams2 = new int[num_teams];
            for (int i = 0; i < num_teams; i++) teams[i] = i;

            // Start the rounds.
            for (int round = 0; round < num_teams; round++)
            {
                for (int i = 0; i < n2; i++)
                {
                    int team1 = teams[n2 - i];
                    int team2 = teams[n2 + i + 1];
                    results[team1, round] = team2;
                    results[team2, round] = team1;
                }

                // Set the team with the bye.
                results[teams[0], round] = BYE;

                // Rotate the array.
                RotateArray(teams);
            }

            return results;
        }

        // Rotate the entries one position.
        private void RotateArray(int[] teams)
        {
            int tmp = teams[teams.Length - 1];
            Array.Copy(teams, 0, teams, 1, teams.Length - 1);
            teams[0] = tmp;
        }

        private int[,] GenerateRoundRobinEven(int num_teams)
        {
            // Generate the result for one fewer teams.
            int[,] results = GenerateRoundRobinOdd(num_teams - 1);

            // Copy the results into a bigger array,
            // replacing the byes with the extra team.
            int[,] results2 = new int[num_teams, num_teams - 1];
            for (int team = 0; team < num_teams - 1; team++)
            {
                for (int round = 0; round < num_teams - 1; round++)
                {
                    if (results[team, round] == BYE)
                    {
                        // Change the bye to the new team.
                        results2[team, round] = num_teams - 1;
                        results2[num_teams - 1, round] = team;
                    }
                    else
                    {
                        results2[team, round] = results[team, round];
                    }
                }
            }

            return results2;
        }

        private int[,] GenerateRoundRobin(int num_teams)
        {
            if (num_teams % 2 == 0)
                return GenerateRoundRobinEven(num_teams);
            else
                return GenerateRoundRobinOdd(num_teams);
        }        
    }
}
