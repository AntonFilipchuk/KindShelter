using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Enitites;
using Core.Interfaces;
using Core.Specifications;
using Core.Specifications.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ShelterWithSpecsController : BaseController
    {
        private readonly IGenericRepository<Pet> _repository;
        private IMapper _mapper;

        public ShelterWithSpecsController(IGenericRepository<Pet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetDTO>>> GetAllPets(
            [FromQuery] PetSpecificationParameters parameters
        )
        {
            var spec = new PetsWithLocationAndBreedSpecification(parameters);
            var pets = await _repository.ListAsync(spec);
            return ReturnMappedCollection<Pet, PetDTO>(pets);
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
