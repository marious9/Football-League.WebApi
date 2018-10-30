using Football_League.Models.BindingModels;
using Football_League.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Services.Services.Interfaces
{
    public interface ITeamService
    {
        Task<ResponseDto<BaseModelDto>> InsertTeamAsync(int leagueId, AddTeamBindingModel model);
        Task<ResponseDto<BaseModelDto>> EditTeamsync(int teamId, EditTeamBindingModel model);
        Task<ResponseDto<BaseModelDto>> DeleteTeamAsync(int teamId);
        ResponseDto<TeamDto> GetTeam(int teamId);
        ResponseDto<TeamsDto> GetAllTeam();
    }
}
