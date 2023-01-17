using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Enitites;

namespace API.Mapper
{
    public class CityMapProfile : Profile
    {
        public CityMapProfile()
        {
            CreateMap<City, CityDTO>()
                .ForMember(
                    cityDto => cityDto.NumberOfAdresses,
                    options => options.MapFrom(city => city.GetNumberOfAdresses())
                );
        }
    }
}
