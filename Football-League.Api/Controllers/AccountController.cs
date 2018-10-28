using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Football_League.Models.BindingModels;
using Football_League.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Football_League.Api.Controllers
{    
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var result = await _accountService.GetUser(userId);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterBindingModel model)
        {
            var result = await _accountService.Register(model);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginBindingModel model)
        {
            var result = await _accountService.Login(model);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("LogOut")]
        public async Task LogOut()
        {
            await _accountService.LogOut();
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordBindingModel model)
        {
            var userId = User.Identity.Name;
            var result = await _accountService.ChangePassword(userId, model);
            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("EditProfile")]
        public async Task<IActionResult> EditProfile([FromBody] UserProfileBindingModel model)
        {
            var userId = User.Identity.Name;
            var result = await _accountService.EditProfile(userId, model);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
