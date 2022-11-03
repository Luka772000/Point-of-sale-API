﻿using AutoMapper;
using POS_Backend.DTOs.Kupci;
using POS_Backend.DTOs.Proizvod;
using POS_Backend.DTOs.User;
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
            CreateMap<KUPAC, CreateKupacDto>().ReverseMap();
            CreateMap<KUPAC, GetKupacDto>().ReverseMap();

        }
    }
}
    