using AutoMapper;
using POS_Backend.DTOs.Proizvod;
using POS_Backend.Dto;
using POS_Backend.Models;

namespace POS_Backend.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppUser, LoginDto>().ReverseMap();
            CreateMap<PROIZVOD, CreateProizvodDto>().ReverseMap();
            CreateMap<PROIZVOD, GetProizvodDto>().ReverseMap();

        }
    }
}
    