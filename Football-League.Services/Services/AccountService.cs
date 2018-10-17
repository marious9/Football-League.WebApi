using Football_League.Models.BindingModels;
using Football_League.Models.Domain;
using Football_League.Models.Dto;
using Football_League.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContext;

        public AccountService(UserManager<User> userManager, IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
            _httpContext = httpContext;
        }

        public async Task<ResponseDto<BaseModelDto>> Register(RegisterBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();
            var userFindByName = await _userManager.FindByNameAsync(model.Username);
            if (userFindByName != null)
            {
                response.Errors.Add("Użytkownik o takiej nazwie już istnieje.");
            }

            var userFingByEmail = await _userManager.FindByEmailAsync(model.Email);
            if (userFingByEmail != null)
            {
                response.Errors.Add("Użytkownik o takim e-mail'u już istnieje.");
            }

            if (userFindByName == null && userFingByEmail == null)
            {
                var user = new User()
                {
                    Id = model.Username,
                    Email = model.Email,
                    PasswordHash = model.Password,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    UserName = model.Username,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Errors.Any())
                {
                    foreach (var error in result.Errors)
                    {
                        response.Errors.Add(error.Description);
                    }
                    return response;
                }
            }

            return response;
        }
        public async Task<ResponseDto<LoginDto>> Login(LoginBindingModel model)
        {
            var response = new ResponseDto<LoginDto>();
            var user = await _userManager.FindByNameAsync(model.Login);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(model.Login);
            }

            var checkPassword = await _userManager.CheckPasswordAsync(user, model.Password);
            if (user != null && checkPassword)
            {
                var identity = new ClaimsIdentity("Identity.Application");
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Id));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

                await _httpContext.HttpContext.SignInAsync("Identity.Application", new ClaimsPrincipal(identity), new AuthenticationProperties { IsPersistent = true });
                return response;
            }
            response.Errors.Add("Błędny login lub hasło.");
            return response;
        }

        public async Task LogOut()
        {
            await _httpContext.HttpContext.SignOutAsync("Identity.Application");
        }

        public async Task<ResponseDto<BaseModelDto>> ChangePassword(string userId, ChangePasswordBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();
            var user = await _userManager.FindByNameAsync(userId);

            if (user == null)
            {
                response.Errors.Add("Nie znaleziona użytkownika w bazie danych.");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);
            if (result.Errors.Any())
            {
                foreach (var error in result.Errors)
                {
                    response.Errors.Add(error.Description);
                }
                return response;
            }

            return response;
        }

        public async Task<ResponseDto<BaseModelDto>> EditProfile(string userId, UserProfileBindingModel model)
        {
            var response = new ResponseDto<BaseModelDto>();
            var user = await _userManager.FindByNameAsync(userId);

            if (user == null)
            {
                response.Errors.Add("Nie znaleziona użytkownika w bazie danych.");
            }

            user.Firstname = model.Firstname;
            user.Lastname = model.Lastname;

            var result = await _userManager.UpdateAsync(user);

            if (result.Errors.Any())
            {
                foreach (var error in result.Errors)
                {
                    response.Errors.Add(error.Description);
                }
                return response;
            }
            return response;
        }
    
    }
}
