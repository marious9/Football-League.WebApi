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
    public class MatchService : IMatchService
    {
        private readonly ITeamService _teamService;
        private readonly ITeamRepository _teamRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly ILeagueRepository _leagueRepository;
        private readonly IMapper _mapper;

        public MatchService(ITeamService teamService, IMatchRepository matchRepository, ILeagueRepository leagueRepository, ITeamRepository teamRepository, IMapper mapper)
        {
            _teamService = teamService;
            _teamRepository = teamRepository;
            _matchRepository = matchRepository;
            _leagueRepository = leagueRepository;
            _mapper = mapper;
        }

        public Task<ResponseDto<BaseModelDto>> DeleteMatchAsync(int matchId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<BaseModelDto>> EditMatchAsync(int matchId, EditMatchBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResponseDto<MatchesDto> GetAllMatches()
        {
            var response = new ResponseDto<MatchesDto>
            {
                Object = new MatchesDto()
            };

            var matches = _matchRepository.GetAll();

            response.Object.Matches = _mapper.Map<List<MatchDto>>(matches);

            return response;
        }

        public ResponseDto<MatchDto> GetMatch(int matchId)
        {
            var response = new ResponseDto<MatchDto>()
            {
                Object = new MatchDto()
            };

            var match = _matchRepository.GetById(matchId);
            if(match == null)
            {
                response.Errors.Add(ServiceErrors.MATCH_DOES_NOT_EXIST);
                return response;
            }

            response.Object = _mapper.Map<MatchDto>(match);

            return response;

        }

        public ResponseDto<MatchesDto> GetMatchesFromLeague(int leagueId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<BaseModelDto>> InsertMatchAsync(int leagueId, AddMatchBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            if(model.HostId == model.AwayId)
            {
                response.Errors.Add(ServiceErrors.MATCH_TEAMS_IDS_CANT_BE_EQUAL);
                return response;
            }

            var league = _leagueRepository.GetById(leagueId);
            if (league == null)
            {
                response.Errors.Add(ServiceErrors.LEAGUE_DOESNT_EXIST);
                return response;
            }

            var teams = _teamRepository.GetTeamsFromLeague(leagueId).ToList();
            if (teams == null)
            {
                response.Errors.Add(ServiceErrors.LEAGUE_DOESNT_EXIST);
                return response;
            }

            var HostIsInLeague = teams.Exists(t => t.Id == model.HostId);
            var AwayIsInLeague = teams.Exists(t => t.Id == model.AwayId);

            if(!(HostIsInLeague && AwayIsInLeague))
            {
                response.Errors.Add(ServiceErrors.MATCH_TEAMS_ARENT_IN_THE_SAME_LEAGUE);
                return response;
            }

            var host = _teamRepository.GetById(model.HostId);
            if(host == null)
            {
                response.Errors.Add(ServiceErrors.TEAM_DOESNT_EXIST);
                return response;
            }

            var away = _teamRepository.GetById(model.AwayId);
            if(away == null)
            {
                response.Errors.Add(ServiceErrors.TEAM_DOESNT_EXIST);
                return response;
            }

            var match = new Match
            {
                Away = away,
                Host = host,
                AwayScore = model.AwayScore,
                HostScore = model.HostScore,
                Date = model.Date,
                League = league,
                Round = model.Round
            };

            await _matchRepository.InsertAsync(match);

            return response;
        }
    }
}
