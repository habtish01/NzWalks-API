﻿using NzWalks.API.Models.Domain;

namespace NzWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region> GetByIDAsync(Guid RegionId);
        Task<Region?> CreateAsync(Region region); 
        Task<Region?> UpdateAsync(Guid RegionId,Region region);
        Task<Region?> DeleteAsync(Guid RegionId);
    }
}
