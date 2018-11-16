using Football_League.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto
{
    public class TeamDto : BaseModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PlayerDto> Players { get; set; }
        public List<MatchDto> Matches { get; set; }
        public LeagueLessDetailsDto League { get; set; }

        public TeamDto()
        {
            Players = new List<PlayerDto>();
            Matches = new List<MatchDto>();
            League = new LeagueLessDetailsDto();
        }
    }
}
