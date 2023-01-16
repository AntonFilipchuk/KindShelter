using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Enitites;

namespace API.Mapper
{
    public class LocationMapProfile : Profile
    {
        public LocationMapProfile()
        {
            CreateMap<Location, LocationDTO>();
        }
    }
}