using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Enitites;

namespace API.Mapper
{
    public class PetMapProfile : Profile
    {
        public PetMapProfile()
        {
            CreateMap<Pet, PetDTO>()
                .ConstructUsing(
                    pet =>
                        new PetDTO(
                            pet.Location!.City,
                            pet.Location!.Street,
                            pet.Location!.House,
                            pet.Location!.FlatNumber
                        )
                )
                .ForMember(
                    petDto => petDto.Breed,
                    options => options.MapFrom(pet => pet.Breed!.BreedName)
                )
                .ForMember(
                    petDto => petDto.AnimalType,
                    options => options.MapFrom(pet => pet.Breed!.Animals!.CollectionName)
                );
        }
    }
}
