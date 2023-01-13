using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;
using Core.Enitites.Breeds;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ShelterController : BaseController
    {
        private readonly IShelterRepository _repository;

        public ShelterController(IShelterRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("pets")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetAnimals()
        {
            return Ok(await _repository.GetPets());
        }

        [HttpGet("animals")]
        public async Task<ActionResult<IEnumerable<Breed>>> GetBreeds()
        {
            return Ok(await _repository.GetAnimals());
        }

        [HttpGet("breeds")]
        public async Task<ActionResult<IEnumerable<Breed>>> GetBreedTypes()
        {
            return Ok(await _repository.GetBreeds());
        }
    }
}