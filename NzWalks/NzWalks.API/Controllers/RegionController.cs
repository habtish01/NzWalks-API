using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NzWalks.API.Data;
using NzWalks.API.DTOs;
using NzWalks.API.Models.Domain;
using NzWalks.API.Repositories;
using NzWalks.API.Validation;

namespace NzWalks.API.Controllers
{
  
    public class RegionController : BaseController
    {
        private readonly IRegionRepository repo;
        private readonly IMapper mapper;

        public RegionController(IRegionRepository repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        #region Get All Method
        [HttpGet]
        [Authorize(Roles ="Reader")]
        public async Task<List<RegionDTO>> GetAll()
        {
            var regions= await repo.GetAllAsync();
            if (regions == null) return null;
            
            var regionDto=mapper.Map<List<RegionDTO>>(regions); 

            return regionDto;
        }
        #endregion

        #region Get By Id Method
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<RegionDTO> GetById([FromRoute] Guid id)
        {
            //accessing the domain model from database
            var region = await repo.GetByIDAsync(id);
            if (region == null) return null;

            //conferting domain model to dto
            var regionDto=mapper.Map<RegionDTO>(region);    
                      
            return regionDto;
        }

        #endregion


        #region Create Method
        [HttpPost]
        [ActionAttributeFilter]
        [Authorize(Roles = "Writer")]
        public async Task<RegionDTO> CreateRegion([FromBody]CreateRegionDTO regionDto)
        {
            if (regionDto == null)
            {
                return null;
            }

            //converting dto to domain
            var region = mapper.Map<Region>(regionDto);
              var CreatedRegion=await repo.CreateAsync(region);
            if (CreatedRegion == null)
            {
                return null;
            }
            var regionsDto = mapper.Map<RegionDTO>(CreatedRegion);


            //return CreatedAtAction(nameof(GetById), new { id = regionsDto.Id },regionsDto);
            return regionsDto;  
        }

        #endregion


        #region Update Method
        [HttpPut]
        [Route("{id:Guid}")]
        [ActionAttributeFilter]
        [Authorize(Roles = "Writer")]

        public async Task<RegionDTO> Update([FromBody]CreateRegionDTO regionDto,[FromRoute]Guid id)
        {
            if (regionDto == null) return null;
          

            var UpdatedRegion =await repo.UpdateAsync(id, regionDto);
            var regionsDto =mapper.Map<RegionDTO>(UpdatedRegion);

            return regionsDto;  
        }


        #endregion


        #region Delete Method
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]

        public async Task<RegionDTO> Delete([FromRoute] Guid id)
        {
           var region=await repo.DeleteAsync(id);
            if(region == null)
            {
                return null;
            }
           

            
            var deltedRegion = mapper.Map<RegionDTO>(region);  
           

            return deltedRegion;
        }


        #endregion


    }

}
