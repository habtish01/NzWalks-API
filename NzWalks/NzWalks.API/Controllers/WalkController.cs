﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NzWalks.API.DTOs;
using NzWalks.API.Models.Domain;
using NzWalks.API.Repositories;

namespace NzWalks.API.Controllers
{
    public class WalkController: BaseController
    {
        private readonly IMapper mapper;
        private readonly IWalksRepository repo;

        public WalkController(IMapper mapper,IWalksRepository repo)
        {
            this.mapper = mapper;
            this.repo = repo;
        }

        [HttpGet]
        public async Task<List<WalkDTO>> GetAllWalks()
        {
            var regions=await repo.GetAllASync();
            if (regions == null) return null;
            //mapping
            var regionsDto=mapper.Map<List<WalkDTO>>(regions);   
            return regionsDto;
        }

        [HttpGet]
        public async Task<WalkDTO> GetWalk(Guid id)
        {
            var region=await repo.GetByIdAsync(id);
            if (region== null) return null;

            //mapping
            var regionDto=mapper.Map<WalkDTO>(region);
            return regionDto;
        }

        [HttpPost]

        public async Task<WalkDTO> CreateWalk(CreateWalkDTO walk)
        {
            if (walk == null) return null;
            //mapping
            var walkDto=mapper.Map<Walk>(walk);    
            var region=await repo.CreateAsync(walkDto);
            //mapping
            var walkDTO=mapper.Map<WalkDTO>(region);
            return walkDTO;
        }

        [HttpPut]
        public async Task<WalkDTO> UpdateWalk(Guid id,CreateWalkDTO CreatewalkDto)
        {
            if (CreatewalkDto== null) return null;
            //mapping
            var walk=mapper.Map<Walk>(CreatewalkDto);
            var walkDomain = await repo.UpdaeAsync(id, walk);
            if (walkDomain == null) return null;
            //mapping
           var walkDto= mapper.Map<WalkDTO>(walkDomain);
            return walkDto;
        }

        [HttpDelete]    
        public async Task<WalkDTO> DeleteWalk(Guid id)
        {
            var walk=await repo.DeleteAsync(id);
            if (walk == null) return null;
            return mapper.Map<WalkDTO>(walk);   
        }
    }
}