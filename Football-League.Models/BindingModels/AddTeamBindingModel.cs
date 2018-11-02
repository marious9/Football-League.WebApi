using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Football_League.Models.BindingModels
{
    public class AddTeamBindingModel
    {
        [Required]
        [StringLength(40, ErrorMessage = "Nazwa drużyny powinna zawierać od 3 do 40 znaków", MinimumLength = 2)]
        public string Name { get; set; }
    }
}
