using AutoMapper;
using NzWalks.API.DTOs;
using NzWalks.API.Models.Domain;

namespace NzWalks.API.Helper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
                //.ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));//when member of each data models are diferrent in name 
             CreateMap<Region,CreateRegionDTO>().ReverseMap().ForMember(x=>x.RegionImageUrl,opt=>opt.MapFrom(x=>x.RegiionImageUrl));   
        }

    }
}
