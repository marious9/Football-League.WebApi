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
    public class StatisticService : IStatisticService
    {
        private readonly IMatchPlayerRepository _matchPlayerRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly ILeagueRepository _leagueRepository;
        private readonly IMapper _mapper;
        private readonly IStatisticRepository _statisticRepository;

        public StatisticService(IMatchPlayerRepository matchPlayerRepository, IPlayerRepository playerRepository,IMatchRepository matchRepository, ILeagueRepository leagueRepository, IMapper mapper, IStatisticRepository statisticRepository)
        {
            _matchPlayerRepository = matchPlayerRepository;
            _playerRepository = playerRepository;
            _matchRepository = matchRepository;
            _leagueRepository = leagueRepository;
            _mapper = mapper;
            _statisticRepository = statisticRepository;
        }

        public ResponseDto<StatisticDto> GetStatistic(int statisticId)
        {
            var response = new ResponseDto<StatisticDto>();

            var statistic = _statisticRepository.GetById(statisticId);

            if(statistic == null)
            {
                response.Errors.Add(ServiceErrors.STATISTIC_DOES_NOT_EXIST);
                return response;
            }

            response.Object = _mapper.Map<StatisticDto>(statistic);

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> InsertAsync(AddStatisticBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();

            var action = new List<Models.Enums.Action>();

            //try
            //{
            //    var actionType = (Models.Enums.Action)Enum.Parse(typeof(Models.Enums.Action), model.Action, true);
            //    action.Add(actionType);
            //}
            //catch
            //{
            //    response.Errors.Add(ServiceErrors.STATISTIC_INVALID_ACTION);
            //    return response;
            //}
                

            var match = _matchRepository.GetById(model.MatchId);
            if(match == null)
            {
                response.Errors.Add(ServiceErrors.MATCH_DOES_NOT_EXIST);
                return response;
            }

            var player = _playerRepository.GetById(model.PlayerId);
            if (player == null)
            {
                response.Errors.Add(ServiceErrors.PLAYER_DOESNT_EXIST);
                return response;
            }

            var matchPlayer = _matchPlayerRepository.GetById(model.MatchId, model.PlayerId);
            if(matchPlayer == null)
            {
                response.Errors.Add(ServiceErrors.MATCH_PLAYER_DOES_NOT_EXIST);
                return response;
            }

            var statistic = new Statistic
            {
                MatchPlayer = matchPlayer,
                Minute = model.Minute,
                Action = model.Action
            };

            await _statisticRepository.InsertAsync(statistic);

            return response;
        }
    }
}
