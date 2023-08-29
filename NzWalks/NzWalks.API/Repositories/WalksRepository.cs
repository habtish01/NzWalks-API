using Microsoft.EntityFrameworkCore;
using NzWalks.API.Data;
using NzWalks.API.Models.Domain;

namespace NzWalks.API.Repositories
{
    public class WalksRepository : IWalksRepository
    {
        private readonly NzWalksDbContext context;

        public WalksRepository(NzWalksDbContext context)
        {
            this.context = context;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await context.walks.AddAsync(walk);
            await context.SaveChangesAsync();   
            return walk;

        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var region=await context.walks.FindAsync(id);   
            if (region == null) { return null; }
             context.walks.Remove(region);
            await context.SaveChangesAsync();
            return region;
        }

        public async Task<List<Walk>> GetAllASync()
        {
         var regions=await context.walks.ToListAsync();
            return regions;
        }

        public async Task<Walk> GetByIdAsync(Guid id)
        {
            var region = await context.walks.FindAsync(id);
            return region;
        }

        public async Task<Walk?> UpdaeAsync(Guid id, Walk walk)
        {
            var region = await context.walks.FindAsync(id);
            if (region == null) return null;
             context.walks.Update(region);
            await context.SaveChangesAsync();
            return region;
        }
    }
}
