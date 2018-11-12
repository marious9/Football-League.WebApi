using Football_League.Models.BindingModels;
using Football_League.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football_League.Api.Controllers
{
    public class TeamController : BaseController
    {
        private readonly ITeamService _teamService;
        private readonly ILeagueTableService _leagueTableService;

        public TeamController(ITeamService teamService, ILeagueTableService leagueTableService)
        {
            _leagueTableService = leagueTableService;
            _teamService = teamService;
        }

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

        [HttpGet]
        public IActionResult GetAllTeams()
        {
            var result = _teamService.GetAllTeams();

            return Ok(result);
        }

        [HttpGet("{teamId}")]
        public IActionResult GetTeam(int teamId)
        {
            var result = _teamService.GetTeam(teamId);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("{leagueId}")]
        public async Task<IActionResult> InsertTeam(int leagueId, [FromBody]AddTeamBindingModel model)
        {
            var result = await _teamService.InsertTeamAsync(leagueId, model);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("{teamId}")]
        public async Task<IActionResult> EditTeam(int teamId, [FromBody]EditTeamBindingModel model)
        {
            var result = await _teamService.EditTeamsync(teamId, model);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{teamId}")]
        public async Task<IActionResult> DeleteTeam(int teamId)
        {
            var result = await _teamService.DeleteTeamAsync(teamId);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
