using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using City.Api.Models.Entities;

namespace City.Api.Services.Repositories
{
    public interface ITownRepository
    {
        Task<Town> GetTownAsync(Guid id, bool includeSights);
        Task<IEnumerable<Town>> GetTownsAsync();
        Task<bool> TownExistsAsync(Guid id);
    }
}