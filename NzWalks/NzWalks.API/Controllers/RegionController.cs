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
                    Id= region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }

            return regionDto;
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<RegionDTO> GetById([FromRoute] Guid id)
        {
            //accessing the domain model from database
            var regions = DbContext.region.FirstOrDefault(u => u.Id == id);
            //conferting domain model to dto
            var regionDto=new RegionDTO{
                Id=regions.Id,Code=regions.Code, Name=regions.Name, RegionImageUrl=regions.RegionImageUrl
            };    
           
                
            
            return regionDto;
        }
       

        [HttpPost]

        public  IActionResult CreateRegion([FromBody]CreateRegionDTO regionDto)
        {
            if (regionDto == null)
            {
                return null;
            }

            //converting dto to domain
            var region = new Region
            {
                Code = regionDto.Code,
                Name = regionDto.Name,
                RegionImageUrl = regionDto.RegiionImageUrl
            };

             DbContext.region.Add(region);
            DbContext.SaveChanges();
            //convert domain to dto
            var regionsDto = new RegionDTO
            {
                Id = region.Id,
                Code = regionDto.Code,
                Name = regionDto.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = regionsDto.Id },regionsDto);
        }

        [HttpPut]
        public IActionResult Update(CreateRegionDTO regionDto,Guid id)
        {
            var checkRegion=DbContext.region.FirstOrDefault(u=>u.Id == id);
            if (checkRegion == null)
            {
                return BadRequest();
            }

            checkRegion.Code= regionDto.Code;
            checkRegion.Name= regionDto.Name;
            checkRegion.RegionImageUrl = regionDto.RegiionImageUrl;

            DbContext.SaveChanges();
            var regionsDto = new RegionDTO
            {
                Id = checkRegion.Id,
                Code = checkRegion.Code,
                Name = checkRegion.Name,
                RegionImageUrl = checkRegion.RegionImageUrl
            };

            return Ok(regionsDto);  
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var checkRegion = DbContext.region.FirstOrDefault(u => u.Id == id);
            if (checkRegion == null)
            {
                return BadRequest();
            }

            DbContext.region.Remove(checkRegion);

            DbContext.SaveChanges();
           

            return Ok("Deleted");
        }

    }

}
