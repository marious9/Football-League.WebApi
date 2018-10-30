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

        public TeamService(ITeamRepository teamRepository, ILeagueRepository leagueRepository)
        {
            _teamRepository = teamRepository;
            _leagueRepository = leagueRepository;
        }

        public Task<ResponseDto<BaseModelDto>> DeleteTeamAsync(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<BaseModelDto>> EditTeamsync(int teamId, EditTeamBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResponseDto<TeamsDto> GetAllTeam()
        {
            throw new NotImplementedException();
        }

        public ResponseDto<TeamDto> GetTeam(int teamId)
        {
            throw new NotImplementedException();
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
