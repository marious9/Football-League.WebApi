using Football_League.Models.BindingModels;
using Football_League.Models.Dto;
using Football_League.Models.Dto.TableDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Football_League.Services.Services.Interfaces
{
    public interface ILeagueService
    {
        
        Task<ResponseDto<BaseModelDto>> DeleteLeague(int leagueId);
        Task<ResponseDto<BaseModelDto>> InsertLeagueAsync(AddLeagueBindingModel model);
        Task<ResponseDto<BaseModelDto>> EditLeagueAsync(int leagueId, EditLeagueBindingModel model);
        ResponseDto<LeagueDto> GetLeague(int leagueId);
        ResponseDto<LeaguesDto> GetAllLeagues();
    }
}
