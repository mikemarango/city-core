using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City.Api.Models.DTOs
{
    public class TownNoSightsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
