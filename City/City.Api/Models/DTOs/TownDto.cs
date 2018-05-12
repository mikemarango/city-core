using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace City.Api.Models.DTOs
{
    public class TownDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Enter a name")]
        [MaxLength(30, ErrorMessage = "Name (including spaces) should be less than 30 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter a description")]
        [MaxLength(200, ErrorMessage = "Description (including spaces) should be less than 200 characters")]
        public string Description { get; set; }
        public ICollection<SightDto> Sights { get; set; } = new List<SightDto>();
        public int Sightings => Sights.Count;
    }
}
