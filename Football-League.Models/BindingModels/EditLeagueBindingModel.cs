using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Football_League.Models.BindingModels
{
    public class EditLeagueBindingModel
    {
        [Required]
        [StringLength(40, ErrorMessage = "Nazwa Ligi powinien zawierać od 3 do 40 znaków", MinimumLength = 3)]
        public string Name { get; set; }    
    }
}
