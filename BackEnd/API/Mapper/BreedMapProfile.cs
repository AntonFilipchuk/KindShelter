using API.ReturnObjects.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Mapper
{
    public class BreedMapProfile : Profile
    {
        public BreedMapProfile()
        {
            CreateMap<Breed, BreedDTO>()
                .ForMember(
                    breedDto => breedDto.Animal,
                    options => options.MapFrom(breed => breed.Animal.AnimalName)
                )
                .ForMember(
                    breedDto => breedDto.NumberOfPets,
                    options => options.MapFrom(breed => breed.GetNumberOfPets()
                  )
                );
        }
    }
}
