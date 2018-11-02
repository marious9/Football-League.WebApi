using Football_League.Models.BindingModels;
using Football_League.Services.Services.Interfaces;
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
    }
}
