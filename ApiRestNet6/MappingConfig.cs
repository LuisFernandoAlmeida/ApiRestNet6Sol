using ApiRestNet6.Modelos;
using ApiRestNet6.Modelos.Dto;
using AutoMapper;

namespace ApiRestNet6
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa, VillaDto>().ReverseMap();
            CreateMap<Villa, VillaUpdateDto>().ReverseMap();
            CreateMap<Villa, VillaCreateDto>().ReverseMap() ;
        }
    }
}
