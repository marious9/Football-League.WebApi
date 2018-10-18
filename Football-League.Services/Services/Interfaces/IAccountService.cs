using Football_League.Models.BindingModels;
using Football_League.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Services.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ResponseDto<BaseModelDto>> Register(RegisterBindingModel model);
        Task<ResponseDto<LoginDto>> Login(LoginBindingModel model);
        Task LogOut();
        Task<ResponseDto<BaseModelDto>> ChangePassword(string userId, ChangePasswordBindingModel model);
        Task<ResponseDto<BaseModelDto>> EditProfile(string userId, UserProfileBindingModel model);
        Task<ResponseDto<GetUserDto>> GetUser(string userId);
    }
}
