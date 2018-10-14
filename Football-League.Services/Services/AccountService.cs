using Football_League.Models.BindingModels;
using Football_League.Models.Domain;
using Football_League.Models.Dto;
using Football_League.Services.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;

        public AccountService(UserManager<User> userManager)
        {
            _userManager = userManager;
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
    }
}
