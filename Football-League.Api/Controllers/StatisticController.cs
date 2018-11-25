using Football_League.Models.BindingModels;
using Football_League.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football_League.Api.Controllers
{
    public class StatisticController: BaseController
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [AllowAnonymous]
        [HttpGet("League/{leagueId}")]
        public IActionResult GetLeagueRanking(int leagueId)
        {
            var result = _statisticService.GetLeagueStatistics(leagueId);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("Match/{matchId}")]
        public IActionResult GetMatchStatistics(int matchId)
        {
            var result = _statisticService.GetMatchStatistics(matchId);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{statisticId}")]
        public IActionResult GetStatistic(int statisticId)
        {
            var result = _statisticService.GetStatistic(statisticId);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertStatistic([FromBody]AddStatisticBindingModel model)
        {
            var result = await _statisticService.InsertAsync(model);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
