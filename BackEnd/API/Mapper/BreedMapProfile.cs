using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ReturnObjects.DTOs;
using AutoMapper;
using Core.Enitites;

namespace API.Mapper
{
    public class BreedMapProfile : Profile
    {
        public BreedMapProfile()
        {
            CreateMap<Breed, BreedDTO>()
                .ForMember(
                    breedDto => breedDto.AnimalCollectionName,
                    options => options.MapFrom(breed => breed.Animals!.CollectionName)
                )
                .ForMember(
                    breedDto => breedDto.NumberOfPets,
                    options => options.MapFrom(breed => breed.GetNumberOfPets()
                  )
                );
        }
    }
}
