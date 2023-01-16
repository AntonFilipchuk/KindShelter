using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Enitites;

namespace API.Mapper
{
    public class AnimalMapProfile : Profile
    {
        public AnimalMapProfile()
        {
            CreateMap<Animals, AnimalsDTO>()
                .ForMember(
                    animalDTO => animalDTO.Breeds,
                    options => options.MapFrom(animal => animal.BreedsList())
                );
        }
    }
}
