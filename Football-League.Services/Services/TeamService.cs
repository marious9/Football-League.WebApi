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
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ILeagueRepository _leagueRepository;
        private readonly IMapper _mapper;

        public TeamService(ITeamRepository teamRepository, ILeagueRepository leagueRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _leagueRepository = leagueRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<BaseModelDto>> DeleteTeamAsync(int teamId)
        {
            var response = new ResponseDto<BaseModelDto>();

            var team = _teamRepository.GetById(teamId);
            if (team == null)
            {
                response.Errors.Add(ServiceErrors.TEAM_DOESNT_EXIST);
                return response;
            }
            await _teamRepository.DeleteAsync(team);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> EditTeamsync(int teamId, EditTeamBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var team = _teamRepository.GetById(teamId);
            if(team == null)
            {
                response.Errors.Add(ServiceErrors.TEAM_DOESNT_EXIST);
                return response;
            }
            team.Name = model.Name;
            await _teamRepository.EditAsync(team);

            return response;
        }

        public ResponseDto<TeamsDto> GetAllTeams()
        {
            var response = new ResponseDto<TeamsDto>
            {
                Object = new TeamsDto()
            };

            var teams = _teamRepository.GetAll();

            response.Object.Teams = _mapper.Map<List<TeamDto>>(teams);

            return response;
        }

        public ResponseDto<TeamDto> GetTeam(int teamId)
        {
            var response = new ResponseDto<TeamDto>();

            var team = _teamRepository.GetById(teamId);
            if(team == null)
            {
                response.Errors.Add(ServiceErrors.TEAM_DOESNT_EXIST);
                return response;
            }
            //TODO mapper probably cant see leagueDto inside TeamDto/ I didnt check it.

            response.Object = _mapper.Map<TeamDto>(team);

            return response;

        }

        public async Task<ResponseDto<BaseModelDto>> InsertTeamAsync(int leagueId, AddTeamBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var league = _leagueRepository.GetById(leagueId);
            if(league == null)
            {
                response.Errors.Add(ServiceErrors.LEAGUE_DOESNT_EXIST);
                return response;
            }

            var team = new Team
            {
                League = league,
                Name = model.Name
            };

            var teams = _teamRepository.GetAll().ToList();
            var exists = teams.Exists(t => t.Name == model.Name);
            if(exists)
            {
                response.Errors.Add(ServiceErrors.TEAM_WITH_THAT_NAME_ALREADY_EXISTS);
                return response;
            }

            await _teamRepository.InsertAsync(team);

            return response;



        }
    }
}
