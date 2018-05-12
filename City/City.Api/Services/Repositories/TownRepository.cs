using City.Api.Data;
using City.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City.Api.Services.Repositories
{
    public class TownRepository : ITownRepository
    {
        public TownRepository(TownContext context)
        {
            Context = context;
        }

        public TownContext Context { get; }

        public async Task<IEnumerable<Town>> GetTownsAsync()
        {
            return await Context.Towns.OrderBy(t => t.Name).ToListAsync();
        }

        public async Task<Town> GetTownAsync(Guid id, bool includeSights)
        {
            if (includeSights)
                return await Context.Towns
                    .Include(t => t.Sights)
                    .FirstOrDefaultAsync(t => t.Id == id);

            return await Context.Towns.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<bool> TownExistsAsync(Guid id)
        {
            return await Context.Towns.AnyAsync(t => t.Id == id);
        }
    }
}
