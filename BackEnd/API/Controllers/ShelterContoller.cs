using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ReturnObjects.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ShelterController : BaseController
    {
        private readonly IShelterRepository _repository;
        private readonly IMapper _mapper;

        public ShelterController(IShelterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("pets")]
        public async Task<ActionResult<IEnumerable<PetDTO>>> GetPets()
        {
            //return Ok(await _repository.GetPetsAsync());
            return ReturnMappedCollection<Pet, PetDTO>(await _repository.GetPetsAsync());
        }

        [HttpGet("pets/{id}")]
        public async Task<ActionResult<PetDTO>> GetPetById(int id)
        {
            return ReturnMappedObject<Pet, PetDTO>(await _repository.GetPetByIdAsync(id));
        }

        [HttpGet("animals")]
        public async Task<ActionResult<IEnumerable<AnimalDTO>>> GetAnimals()
        {
            return ReturnMappedCollection<Animal, AnimalDTO>(await _repository.GetAnimalsAsync());
        }

        [HttpGet("animals/{id}")]
        public async Task<ActionResult<AnimalDTO>> GetAnimalsById(int id)
        {
            return ReturnMappedObject<Animal, AnimalDTO>(
                await _repository.GetAnimalsByIdAsync(id)
            );
        }

        [HttpGet("breeds")]
        public async Task<ActionResult<IEnumerable<BreedDTO>>> GetBreeds()
        {
            return ReturnMappedCollection<Breed, BreedDTO>(await _repository.GetBreedsAsync());
        }

        [HttpGet("breeds/{id}")]
        public async Task<ActionResult<BreedDTO>> GetBreedById(int id)
        {
            return ReturnMappedObject<Breed, BreedDTO>(await _repository.GetBreedByIdAsync(id));
        }

        private ActionResult<TOut> ReturnMappedObject<TIn, TOut>(in TIn? item)
            where TIn : BaseEntity
            where TOut : BaseDTO
        {
            if (item is null)
            {
                return NotFound();
            }

            TOut mappedObject = _mapper.Map<TIn, TOut>(item);
            return Ok(mappedObject);
        }

        private ActionResult<IEnumerable<Tout>> ReturnMappedCollection<Tin, Tout>(
            IEnumerable<Tin>? collection
        )
            where Tin : BaseEntity
            where Tout : BaseDTO
        {
            if (collection is null || collection.Count() == 0)
            {
                return NotFound();
            }

            IEnumerable<Tout> mappedCollection = _mapper.Map<IEnumerable<Tin>, IEnumerable<Tout>>(
                collection
            );

            return Ok(mappedCollection);
        }
    }
}
