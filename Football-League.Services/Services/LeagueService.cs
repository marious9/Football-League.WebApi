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
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository _leagueRepository;
        private readonly IMapper _mapper;

        public LeagueService(ILeagueRepository leagueRepository, IMapper mapper)
        {
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
            var response = new ResponseDto<LeagueDto>();

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
    }
}
