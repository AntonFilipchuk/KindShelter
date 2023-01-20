using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ReturnObjects.DTOs;
using AutoMapper;
using Core.Enitites;

namespace API.Mapper
{
    public class AdressMapProfile : Profile
    {
        public AdressMapProfile()
        {
            CreateMap<Adress, AdressDTO>()
                .ForMember(
                    adressDto => adressDto.Street,
                    options => options.MapFrom(adress => adress.Street)
                )
                .ForMember(
                    adressDto => adressDto.HouseNumber,
                    options => options.MapFrom(adress => adress.HouseNumber)
                )
                .ForMember(
                    adressDto => adressDto.FlatNumber,
                    options => options.MapFrom(adress => adress.FlatNumber)
                );
        }
    }
}
