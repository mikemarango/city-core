using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace City.Api.Models.DTOs
{
    public class TownCreateDto
    {
        [Required(ErrorMessage = "You must enter a name"), MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200, ErrorMessage = "The description should not exceed 200 words")]
        public string Description { get; set; }
    }
}
