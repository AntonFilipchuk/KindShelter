using API.ReturnObjects.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Mapper
{
    public class PetMapProfile : Profile
    {
        public PetMapProfile()
        {
            CreateMap<Pet, PetDTO>()
                .ForMember(
                    petDto => petDto.Breed,
                    options => options.MapFrom(pet => pet.Breed.BreedName)
                )
                .ForMember(
                    petDto => petDto.Animal,
                    options => options.MapFrom(pet => pet.Breed.Animal.AnimalName)
                );
        }
    }
}
