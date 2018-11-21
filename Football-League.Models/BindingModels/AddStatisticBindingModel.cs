using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Football_League.Models.BindingModels
{
    public class AddStatisticBindingModel
    {
        [Required]
        [Range(0, 90, ErrorMessage = "Statystykę można dodać tylko podczas trwania meczu.")]
        public int Minute { get; set; }
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public int MatchId { get; set; }
        [Required]
        public Enums.Action Action { get; set; }
    }
}
