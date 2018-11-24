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
    public class MatchController : BaseController
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [AllowAnonymous]
        [HttpGet("League/{leagueId}")]
        public IActionResult GetMatchesFromLeague(int leagueId)
        {
            var result = _matchService.GetMatchesFromLeague(leagueId);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{matchId}")]
        public IActionResult GetMatch(int matchId)
        {
            var result = _matchService.GetMatch(matchId);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllMatches()
        {
            var result = _matchService.GetAllMatches();

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("{leagueId}")]
        public async Task<IActionResult> InsertMatch(int leagueId, AddMatchBindingModel model)
        {
            var result = await _matchService.InsertMatchAsync(leagueId, model);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("{matchId}")]
        public async Task<IActionResult> EditMatch(int matchId, EditMatchBindingModel model)
        {
            var result = await _matchService.EditMatchAsync(matchId, model);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{matchId}")]
        public async Task<IActionResult> DeleteMatch(int matchId)
        {
            var result = await _matchService.DeleteMatchAsync(matchId);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
