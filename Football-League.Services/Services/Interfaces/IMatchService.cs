using Football_League.Models.BindingModels;
using Football_League.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Services.Services.Interfaces
{
    public interface IMatchService
    {
        Task<ResponseDto<BaseModelDto>> InsertMatchAsync(int leagueId, AddMatchBindingModel model);
        Task<ResponseDto<BaseModelDto>> EditMatchAsync(int matchId, EditMatchBindingModel model);
        Task<ResponseDto<BaseModelDto>> DeleteMatchAsync(int matchId);
        ResponseDto<MatchDto> GetMatch(int matchId);
        ResponseDto<MatchesDto> GetAllMatches();
        ResponseDto<MatchesDto> GetMatchesFromLeague(int leagueId);
    }
}
