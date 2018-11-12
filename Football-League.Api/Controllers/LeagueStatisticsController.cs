using Football_League.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football_League.Api.Controllers
{
    public class LeagueStatisticsController: BaseController
    {
        private readonly ILeagueTableService _leagueTableService;

        public LeagueStatisticsController(ILeagueTableService leagueTableService)
        {
            _leagueTableService = leagueTableService;
        }

        [AllowAnonymous]
        [HttpGet("{leagueId}")]
        public IActionResult GetTable(int leagueId)
        {
            var result = _leagueTableService.GetLeagueTable(leagueId);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
