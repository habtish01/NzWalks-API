using NzWalks.API.Models.Domain;

namespace NzWalks.API.Repositories
{
    public interface IWalksRepository
    {
        Task<List<Walk>> GetAllASync();
        Task<Walk> GetByIdAsync(Guid id);
        Task<Walk> CreateAsync(Walk walk);
        Task<Walk?> UpdaeAsync(Guid id,Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
