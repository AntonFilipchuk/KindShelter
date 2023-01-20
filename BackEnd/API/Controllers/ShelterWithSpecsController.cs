using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ReturnObjects.DTOs;
using AutoMapper;
using Core.Enitites;
using Core.Helpers;
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

        [HttpGet("pets")]
        public async Task<ActionResult<Pagination<PetDTO>>> GetAllPets(
            [FromQuery] PetSpecificationParameters parameters
        )
        {
            var spec = new PetsWithLocationAndBreedSpecification(parameters);
            DataForPagination<Pet> petsData = await _repository.GetEntitiesBySpecForPaginationAsync(
                spec
            );

            return ReturnMappedCollection<Pet, PetDTO>(petsData, parameters);
        }

        [HttpGet("pets/{id}")]
        public async Task<ActionResult<PetDTO>> GetPetByIdAsync(int id)
        {
            var spec = new PetWithLocationAndBreedSpecification(id);
            Pet? pet = await _repository.GetEntityBySpec(spec);
            return ReturnMappedObject<Pet, PetDTO>(pet);
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

        private ActionResult<Pagination<Tout>> ReturnMappedCollection<Tin, Tout>(
            in DataForPagination<Tin> data,
            in IParameters parameters
        )
            where Tin : BaseEntity
            where Tout : BaseDTO
        {
            IEnumerable<Tin>? objectList = data.ObjectList;
            int numberOfObjects = data.NumberOfObjectsInDB;

            if (objectList is null || objectList.Count() == 0)
            {
                return NotFound();
            }

            IEnumerable<Tout> mappedCollection = _mapper.Map<IEnumerable<Tin>, IEnumerable<Tout>>(
                objectList
            );

            return Ok(
                new Pagination<Tout>(
                    parameters.PageIndex,
                    parameters.PageSize,
                    numberOfObjects,
                    mappedCollection
                )
            );
        }
    }
}
