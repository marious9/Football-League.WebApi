using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class TeamsDto : BaseModelDto
    {
        public List<TeamDto> Teams { get; set; }

        public TeamsDto()
        {
            Teams = new List<TeamDto>();
        }
    }
}
