using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City.Api.Models.Entities
{
    public class Sight
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid TownId { get; set; }
        public Town Town { get; set; }
    }
}
