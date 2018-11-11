using Football_League.Api.Controllers;
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
    public class LeagueController : BaseController 
    {
        private readonly IAccountService _accountService;
        private readonly ILeagueService _leagueService;

        public LeagueController(IAccountService accountService, ILeagueService leagueService)
        {
            _accountService = accountService;
            _leagueService = leagueService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllLeagues()
        {
            var result = _leagueService.GetAllLeagues();
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{leagueId}")]
        public IActionResult GetLeague(int leagueId)
        {
            var result = _leagueService.GetLeague(leagueId);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertLeague(AddLeagueBindingModel model)
        {
            var result = await _leagueService.InsertLeagueAsync(model);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("{leagueId}")]
        public async Task<IActionResult> EditLeague(int leagueId, EditLeagueBindingModel model)
        {
            var result = await _leagueService.EditLeagueAsync(leagueId, model);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{leagueId}")]
        public async Task<IActionResult> DeleteLeague(int leagueId)
        {
            var result = await _leagueService.DeleteLeague(leagueId);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
