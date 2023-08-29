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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seeding data to database on model creating when the application launched

            //seeding data for difficulties

            var difficultiess = new List<Difficulty>
            {
                new Difficulty {
                       Id = Guid.Parse("E28F4960-9DE0-4116-A162-BB23540167F9"),             

                       Name = "Easy"
                         },
                 new Difficulty {
                       Id = Guid.Parse("0483B46D-C8C0-44AF-AB9C-BB828395875E"),

                       Name = "Medium"
                          },
                  new Difficulty {
                      Id = Guid.Parse("F0F60887-3722-46B7-9712-6080D50B643A"),
                      Name = "Hard"
                        }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficultiess);

            //seeding data to  regions

            var regions = new List<Region> {
                   new Region
                   {
                       Id = Guid.Parse("7FFF524E-6EB8-4D15-A00D-90057EF127A0"),
                       Name="Amhara",
                       Code="AM",
                       RegionImageUrl="image.png"
                   },
                   new Region
                   {
                       Id = Guid.Parse("1B283634-ABE1-4710-B00C-9CD0A4D8B294"),
                       Name="AJerbaja",
                       Code="AJ",
                       RegionImageUrl="image.png"
                   },
                   new Region
                   {
                       Id =Guid.Parse("166702EF-0511-458B-A360-CE44344CC87A"),
                       Name="Bagladish",
                       Code="BM",
                       RegionImageUrl="image.png"
                   },
                   new Region
                   {
                       Id =Guid.Parse("C742FF73-BACB-46E9-AC30-51B1EAE05746"),
                       Name="Dirediwa",
                       Code="DW",
                       RegionImageUrl="image.png"
                   }



            };
            modelBuilder.Entity<Region>().HasData(regions);

            //seeding data to walk

            var walks = new List<Walk> {
                   new Walk
                   {
                       Id = Guid.Parse("C3E30540-DC77-4064-98F3-773B57BEA500"),
                       Name="Going to dubai",
                       Description="I was going to dubai to make myself enjoy",
                       lengthInKm=19090, 
                       WalkImageUrl="Walk.png",
                       RegionId=Guid.Parse("7FFF524E-6EB8-4D15-A00D-90057EF127A0"),
                       DifficultyId=Guid.Parse("F0F60887-3722-46B7-9712-6080D50B643A")
                                          },
                   new Walk
                   {
                       Id = Guid.Parse("12F84C68-121F-4394-A649-569B4321BE10"),
                       Name="Going to Elias",
                       Description="I was going to dubai to make myself enjoy",
                       lengthInKm=1,
                       WalkImageUrl="Walk.png",
                       RegionId=Guid.Parse("1B283634-ABE1-4710-B00C-9CD0A4D8B294"),
                       DifficultyId=Guid.Parse("0483B46D-C8C0-44AF-AB9C-BB828395875E")
                    },
                    new Walk
                    {
                       Id = Guid.Parse("8E682712-2833-46D0-B705-1AA52EE39F20"),
                       Name="Going to Nework",
                       Description="I was going to dubai to make myself enjoy",
                       lengthInKm=1,
                       WalkImageUrl="Walk.png",
                       RegionId=Guid.Parse("166702EF-0511-458B-A360-CE44344CC87A"),
                       DifficultyId=Guid.Parse("0483B46D-C8C0-44AF-AB9C-BB828395875E")
                     },
                    new Walk
                    {
                       Id = Guid.Parse("0F17DDD8-9FF3-4C3D-A019-C878E536AB1B"),
                       Name="Going to London",
                       Description="I was going to dubai to make myself enjoy",
                       lengthInKm=1,
                       WalkImageUrl="Walk.png",
                       RegionId=Guid.Parse("C742FF73-BACB-46E9-AC30-51B1EAE05746"),
                       DifficultyId=Guid.Parse("E28F4960-9DE0-4116-A162-BB23540167F9")
                    },



            };
            modelBuilder.Entity<Walk>().HasData(walks);

        }

    }
}
