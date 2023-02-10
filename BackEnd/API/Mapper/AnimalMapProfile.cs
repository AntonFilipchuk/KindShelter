using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ReturnObjects.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Mapper
{
    public class AnimalMapProfile : Profile
    {
        public AnimalMapProfile()
        {
            CreateMap<Animal, AnimalDTO>()
                .ForMember(
                    animalDTO => animalDTO.AnimalName,
                    options => options.MapFrom(animal => animal.AnimalName)
                )
                .ForMember(
                    animalDTO => animalDTO.PluralAnimalName,
                    options => options.MapFrom(animal => animal.PluralAnimalName)
                );
        }
    }
}
