using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NzWalks.API.Data;
using NzWalks.API.DTOs;
using NzWalks.API.Models.Domain;

namespace NzWalks.API.Repositories
{
    public class WalksRepository : IWalksRepository
    {
        private readonly NzWalksDbContext context;
        private readonly IMapper mapper;

        public WalksRepository(NzWalksDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IMapper Mapper => mapper;//for update functionality

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

        public async Task<List<Walk>> GetAllASync(string? filteron, string? filterquery,
           string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            var walks = context.walks.Include("Region").Include("Difficulty").AsQueryable();
            if (String.IsNullOrWhiteSpace(filteron)==false && String.IsNullOrWhiteSpace(filterquery)==false)
            {
               
                if (filteron.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterquery));
                }

            }
            if (String.IsNullOrWhiteSpace(sortBy) == true)
            {
                  if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks= isAscending ? walks.OrderBy(x=>x.Name): walks.OrderByDescending(x=>x.Name);   
                }
                  if(sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.lengthInKm) : walks.OrderByDescending(x => x.lengthInKm);

                }
            }
            var skipWalks = (pageNumber - 1) * pageSize;//formula for pagination
             //walks=walks.Skip(skipWalks).Take(pageSize); 
            return await walks.Skip(skipWalks).Take(pageSize).ToListAsync(); 


            // var regions=await context.walks.Include("Region").Include("Difficulty").ToListAsync();
            //  return regions;
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            var region = await context.walks.Include("Region").Include("Difficulty").FirstOrDefaultAsync(x=>x.Id==id);
            if(region == null) { return null; } 
            return region;
        }

        public async Task<Walk?> UpdaeAsync(Guid id, CreateWalkDTO walkDto)
        {
            var region = await context.walks.FindAsync(id);
            if (region == null) return null;
            //context.walks.Update(region);
            mapper.Map(walkDto, region);
            await context.SaveChangesAsync();
            return region;
        }
    }
}
