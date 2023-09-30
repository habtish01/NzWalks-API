using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NzWalks.API.Data
{
    public class NzWalksAuthDbContext : IdentityDbContext
    {
        public NzWalksAuthDbContext(DbContextOptions<NzWalksAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "f8d58c64-c278-4294-b54c-c43c9b3ea016";
            var writerRoleId = "17f054db-5a2f-4e63-9213-9bd38c70b04e";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,  
                    ConcurrencyStamp = readerRoleId,
                    Name="Reader",
                    NormalizedName="Reader".ToUpper()
                }, 
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name="Writer",
                    NormalizedName="Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);  
        }
        

    }
}
