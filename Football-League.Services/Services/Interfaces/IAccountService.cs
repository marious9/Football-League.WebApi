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
    }
}
