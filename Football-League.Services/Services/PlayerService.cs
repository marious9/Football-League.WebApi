using AutoMapper;
using Football_League.Data.Interfaces;
using Football_League.Models.BindingModels;
using Football_League.Models.Domain;
using Football_League.Models.Dto;
using Football_League.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Services.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ILeagueRepository _leagueRepository;
        public readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public PlayerService(IPlayerRepository playerRepository, ITeamRepository teamRepository, ILeagueRepository leagueRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
            _leagueRepository = leagueRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<BaseModelDto>> InsertPlayerAsync(int teamId, AddPlayerBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var team = _teamRepository.GetById(teamId);
            if (team == null)
            {
                response.Errors.Add(ServiceErrors.TEAM_DOESNT_EXIST);
                return response;
            }

            var player = new Player
            {
                BirthDate = model.BirthDate,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Team = team
            };
            await _playerRepository.InsertAsync(player);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> EditPlayersync(int playerId, EditPlayerBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var player = _playerRepository.GetById(playerId);
            if (player == null)
            {
                response.Errors.Add(ServiceErrors.PLAYER_DOESNT_EXIST);
                return response;
            }

            player.BirthDate = model.BirthDate;
            player.Firstname = model.Firstname;
            player.Lastname = model.Lastname;

            await _playerRepository.EditAsync(player);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> DeletePlayerAsync(int playerId)
        {
            var response = new ResponseDto<BaseModelDto>();

            var player = _playerRepository.GetById(playerId);
            if (player == null)
            {
                response.Errors.Add(ServiceErrors.PLAYER_DOESNT_EXIST);
                return response;
            }

            await _playerRepository.DeleteAsync(player);

            return response;
        }

        public ResponseDto<PlayerDto> GetPlayer(int playerId)
        {
            var response = new ResponseDto<PlayerDto>();

            var player = _playerRepository.GetById(playerId);
            if (player == null)
            {
                response.Errors.Add(ServiceErrors.PLAYER_DOESNT_EXIST);
                return response;
            }

            response.Object = _mapper.Map<PlayerDto>(player);

            return response;
        }

        public ResponseDto<PlayersDto> GetAllPlayers()
        {
            var response = new ResponseDto<PlayersDto>
            {
                Object = new PlayersDto()
            };

            var players = _playerRepository.GetAll();

            if(players == null)
            {
                response.Errors.Add(ServiceErrors.STH_WENT_WRONG);
                return response;
            }

            response.Object.Players = _mapper.Map<List<PlayerDto>>(players);

            return response;
        }
    }
}
