using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Football_League.Models.BindingModels
{
    public class AddMatchBindingModel
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [Range(1,63)]
        public int Round { get; set; }
        [Required]
        [Range(1,50)]
        public int HostScore { get; set; }
        [Required]
        [Range(1, 50)]
        public int AwayScore { get; set; }
        [Required]
        public int HostId { get; set; }
        [Required]
        public int AwayId { get; set; }
    }
}
