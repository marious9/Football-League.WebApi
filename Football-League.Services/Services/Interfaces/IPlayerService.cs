using Football_League.Models.BindingModels;
using Football_League.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Services.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<ResponseDto<BaseModelDto>> InsertPlayerAsync(int teamId, AddPlayerBindingModel model);
        Task<ResponseDto<BaseModelDto>> EditPlayersync(int playerId, EditPlayerBindingModel model);
        Task<ResponseDto<BaseModelDto>> DeletePlayerAsync(int playerId);
        ResponseDto<PlayerDto> GetPlayer(int playerId);
        ResponseDto<PlayersDto> GetAllPlayers();
    }
}
