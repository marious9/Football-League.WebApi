using Football_League.Models.Dto;
using Football_League.Models.Dto.TableDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Services.Services.Interfaces
{
    public interface ILeagueTableService
    {
        ResponseDto<LeagueTableDto> GetLeagueTable(int leagueId);
    }
}
