//using Microsoft.EntityFrameworkCore;


using Microsoft.EntityFrameworkCore;
using NzWalks.API.Models.Domain;

namespace NzWalks.API.Data
{
    public class NzWalksDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public NzWalksDbContext(DbContextOptions<NzWalksDbContext> options):base(options) 
        {
            
        }

        public DbSet<Walk> walks { get; set; } 
        public DbSet<Region> region  { get; set; } 
        public DbSet<Difficulty> difficulty { get; set; } 
    }
}
