using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using City.Api.Models.Entities;

namespace City.Api.Services.Repositories
{
    public interface ISightRepository
    {
        Task<Sight> GetSightAsync(Guid townId, Guid id);
        Task<IEnumerable<Sight>> GetSightsAsync(Guid id);
        Task CreateSightAsync(Guid id, Sight sight);
        Task UpdateSightAsync(Sight sight);
    }
}