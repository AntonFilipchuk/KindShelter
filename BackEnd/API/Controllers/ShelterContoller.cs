using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Enitites; 
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
        public async Task<ActionResult<IEnumerable<PetDTO>>> GetAnimals()
        {
            IEnumerable<Pet> pets = await _repository.GetPets();
            IEnumerable<PetDTO> petDTOs = _mapper.Map<IEnumerable<Pet>, IEnumerable<PetDTO>>(pets);
            return Ok(petDTOs);
        }

        [HttpGet("animals")]
        public async Task<ActionResult<IEnumerable<AnimalDTO>>> GetBreeds()
        {
            IEnumerable<Animals> animals = await _repository.GetAnimals();
            IEnumerable<AnimalDTO> animalDTOs = _mapper.Map<IEnumerable<Animals>, IEnumerable<AnimalDTO>>(animals);
            return Ok(animalDTOs);
        }

        [HttpGet("breeds")]
        public async Task<ActionResult<IEnumerable<Breed>>> GetBreedTypes()
        {
            IEnumerable<Breed> breeds = await _repository.GetBreeds();
            IEnumerable<BreedDTO> breedDTOs = _mapper.Map<IEnumerable<Breed>, IEnumerable<BreedDTO>>(breeds);
            return Ok(breedDTOs);
        }
    }
}