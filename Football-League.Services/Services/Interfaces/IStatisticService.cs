using Football_League.Models.BindingModels;
using Football_League.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Services.Services.Interfaces
{
    public interface IStatisticService
    {
        Task<ResponseDto<BaseModelDto>> InsertAsync(AddStatisticBindingModel model);
        ResponseDto<StatisticDto> GetStatistic(int statisticId);
    }
}
