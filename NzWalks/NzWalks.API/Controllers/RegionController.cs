using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NzWalks.API.Data;
using NzWalks.API.DTOs;
using NzWalks.API.Models.Domain;

namespace NzWalks.API.Controllers
{

    public class RegionController : BaseController
    {
        public NzWalksDbContext DbContext;
        public RegionController(NzWalksDbContext dbContext)
        {
            DbContext = dbContext;
        }
        [HttpGet]
        public async Task<List<RegionDTO>> GetAll()
        {
            List<Region> regions = DbContext.region.ToList();
            var regionDto = new List<RegionDTO>();
            foreach (var region in regions)
            {
                regionDto.Add(new RegionDTO
                {
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }

            return regionDto;
        }
        [HttpGet("{{id:Guid}}")]
        public async Task<RegionDTO> GetById([FromRoute] Guid id)
        {
            //accessing the domain model from database
            var regions = DbContext.region.FirstOrDefault(u => u.Id == id);
            //conferting domain model to dto
            var regionDto=new RegionDTO{
                Code=regions.Code, Name=regions.Name, RegionImageUrl=regions.RegionImageUrl
            };    
           
                
            
            return regionDto;
        }
       

        [HttpPost]

        public  IActionResult CreateRegion(Region region)
        {
            if (region == null)
            {
                return null;
            }

             DbContext.region.Add(region);
            DbContext.SaveChanges();
            return Ok(region);
        }

        
    }

}
