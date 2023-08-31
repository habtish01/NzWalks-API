using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NzWalks.API.Data;
using NzWalks.API.DTOs;
using NzWalks.API.Models.Domain;

namespace NzWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NzWalksDbContext context;
        private readonly IMapper mapper;

        public RegionRepository(NzWalksDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Region?> CreateAsync(Region region)
        {
           
           await context.region.AddAsync(region);
            await context.SaveChangesAsync();   
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid RegionId)
        {
            var Existedregion=await context.region.FirstOrDefaultAsync(u=>u.Id==RegionId);
            if (Existedregion == null) return null;
            context.region.Remove(Existedregion); 
            await context.SaveChangesAsync();   
            return Existedregion;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            var regions=await context.region.ToListAsync(); 
            return regions;
        }

        public async Task<Region> GetByIDAsync(Guid RegionId)
        {
            var region=await context.region.FirstOrDefaultAsync(u => u.Id == RegionId);
            return region;
        }

        public async Task<Region?> UpdateAsync(Guid RegionId,CreateRegionDTO region)
        {
            var Existedregion=await context.region.AsNoTracking().FirstOrDefaultAsync(u=>u.Id==RegionId);
            //context.region.Update(region);  
            if (Existedregion == null) return null;
            //Existedregion.Code= region.Code;    
            //Existedregion.Name= region.Name;
            //Existedregion.RegionImageUrl= region.RegionImageUrl;
            context.region.Attach(Existedregion);   //atach the context with the retrived entity to be tracked by entity
            mapper.Map(region, Existedregion);//we made a changes in the main model but not awared by the cotext be cause we as no tracking method
            await context.SaveChangesAsync();
           return Existedregion;    

        }
    }
}
