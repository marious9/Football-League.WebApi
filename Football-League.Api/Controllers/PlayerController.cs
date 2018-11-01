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
    public class PlayerController : BaseController
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllPlayers()
        {
            var result = _playerService.GetAllPlayers();

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{playerId}")]
        public IActionResult GetPlayer(int playerId)
        {
            var result = _playerService.GetPlayer(playerId);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("{teamId}")]
        public async Task<IActionResult> InsertPlayer(int teamId, [FromBody]AddPlayerBindingModel model)
        {
            var result = await _playerService.InsertPlayerAsync(teamId, model);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("{playerId}")]
        public async Task<IActionResult> EditPlayer(int playerId, [FromBody]EditPlayerBindingModel model)
        {
            var result = await _playerService.EditPlayersync(playerId, model);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        [HttpDelete("{playerId}")]
        public async Task<IActionResult> DeletePlayer(int playerId)
        {
            var result = await _playerService.DeletePlayerAsync(playerId);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }
    }
}
