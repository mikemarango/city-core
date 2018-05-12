using City.Api.Data;
using City.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace City.Api.Services.Repositories
{
    public class SightRepository : ISightRepository
    {
        public SightRepository(TownContext context)
        {
            Context = context;
        }

        public TownContext Context { get; }

        public async Task<IEnumerable<Sight>> GetSightsAsync(Guid id)
        {
            return await Context.Sights.Where(t => t.TownId == id).ToListAsync();
        }

        public async Task<Sight> GetSightAsync(Guid townId, Guid id)
        {
            //return (await GetSightsAsync(townId)).SingleOrDefault(s => s.Id == id);
            return await Context.Sights.FirstOrDefaultAsync(s => s.TownId == id && s.Id == id);
        }

        public async Task CreateSightAsync(Guid id, Sight sight)
        {
            var town = await Context.Towns.FirstOrDefaultAsync(t => t.Id == id);
            town.Sights.Add(sight);
            await Context.SaveChangesAsync();
        }
    }
}
