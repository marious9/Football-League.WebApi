using System;
using System.Collections.Generic;
using System.Text;

namespace Football_League.Models.Dto.TableDto
{
    public class TableRowDto: BaseModelDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesDrawn { get; set; }
        public int MatchesLost { get; set; }
        public int GoalsLost { get; set; }
        public int GoalsScored { get; set; }
        public int Points { get; set; }
    }
}
