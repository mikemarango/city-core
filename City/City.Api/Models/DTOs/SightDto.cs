using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace City.Api.Models.DTOs
{
    public class SightDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Enter a name")]
        [MaxLength(50, ErrorMessage = "Name (including spaces) should be less than 30 characters")]
        public string Name { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Description (including spaces) should be less than 500 characters")]
        public string Description { get; set; }
    }
}
