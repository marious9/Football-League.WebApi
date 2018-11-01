using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class PlayersDto : BaseModelDto
    {
        public List<PlayerDto> Players { get; set; }
        public PlayersDto()
        {
            Players = new List<PlayerDto>();
        }
    }
}
