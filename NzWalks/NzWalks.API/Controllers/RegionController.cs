using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        #region Get All Method
        [HttpGet]
        
        public async Task<List<RegionDTO>> GetAll()
        {
            List<Region> regions = await DbContext.region.ToListAsync();
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
        #endregion

        #region Get By Id Method
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<RegionDTO> GetById([FromRoute] Guid id)
        {
            //accessing the domain model from database
            var regions = await DbContext.region.FirstOrDefaultAsync(u => u.Id == id);
            //conferting domain model to dto
            var regionDto=new RegionDTO{
                Id=regions.Id,Code=regions.Code, Name=regions.Name, RegionImageUrl=regions.RegionImageUrl
            };    
           
                
            
            return regionDto;
        }

        #endregion


        #region Create Method
        [HttpPost]

        public async Task<RegionDTO> CreateRegion([FromBody]CreateRegionDTO regionDto)
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

            await DbContext.region.AddAsync(region);
            await DbContext.SaveChangesAsync();
            //convert domain to dto
            var regionsDto = new RegionDTO
            {
                Id = region.Id,
                Code = regionDto.Code,
                Name = regionDto.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            //return CreatedAtAction(nameof(GetById), new { id = regionsDto.Id },regionsDto);
            return regionsDto;  
        }

        #endregion


        #region Update Method
        [HttpPut]
        public async Task<RegionDTO> Update(CreateRegionDTO regionDto,Guid id)
        {
            var checkRegion=await DbContext.region.FirstOrDefaultAsync(u=>u.Id == id);
            if (checkRegion == null)
            {
                return null;
            }

            checkRegion.Code= regionDto.Code;
            checkRegion.Name= regionDto.Name;
            checkRegion.RegionImageUrl = regionDto.RegiionImageUrl;

            await DbContext.SaveChangesAsync();
            var regionsDto = new RegionDTO
            {
                Id = checkRegion.Id,
                Code = checkRegion.Code,
                Name = checkRegion.Name,
                RegionImageUrl = checkRegion.RegionImageUrl
            };

            return regionsDto;  
        }


        #endregion


        #region Delete Method
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var checkRegion = await DbContext.region.FirstOrDefaultAsync(u => u.Id == id);
            if (checkRegion == null)
            {
                return BadRequest();
            }

            DbContext.region.Remove(checkRegion);

            await DbContext.SaveChangesAsync();

            var deltedRegion = new RegionDTO
            { 
                Id = checkRegion.Id,    
                Code = checkRegion.Code,
                Name = checkRegion.Name,
                RegionImageUrl = checkRegion.RegionImageUrl
            };
           

            return Ok(deltedRegion);
        }


        #endregion


    }

}
