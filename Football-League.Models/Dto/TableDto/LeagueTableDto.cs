using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto.TableDto
{
    public class LeagueTableDto: BaseModelDto
    {
        public List<LeagueTableRowDto> Teams { get; set; }

        public LeagueTableDto()
        {
            Teams = new List<LeagueTableRowDto>();
        }
    }
}
