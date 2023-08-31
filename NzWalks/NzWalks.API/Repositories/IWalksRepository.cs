using NzWalks.API.DTOs;
using NzWalks.API.Models.Domain;

namespace NzWalks.API.Repositories
{
    public interface IWalksRepository
    {
        Task<List<Walk>> GetAllASync(string? filteron,string? filterquery);
        Task<Walk> GetByIdAsync(Guid id);
        Task<Walk> CreateAsync(Walk walk);
        Task<Walk?> UpdaeAsync(Guid id,CreateWalkDTO walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
