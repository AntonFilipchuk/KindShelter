using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using API.ReturnObjects.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
using Core.Specifications.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ShelterWithSpecsController : BaseController
    {
        private readonly IGenericRepository<Pet> _petRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Animal> _animalRepository;
        private IMapper _mapper;

        public ShelterWithSpecsController(
            IGenericRepository<Pet> petRepository,
            IGenericRepository<Product> productRepository,
            IGenericRepository<Animal> animalRepository,
            IMapper mapper
        )
        {
            _petRepository = petRepository;
            _productRepository = productRepository;
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        [HttpGet("pets")]
        [ProducesResponseType(typeof(Pagination<PetDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<Pagination<PetDTO>>> GetAllPets(
            [FromQuery] PetSpecificationParameters parameters
        )
        {
            var spec = new PetsWithBreedAndAnimalSpecification(parameters);
            DataForPagination<Pet> petsData =
                await _petRepository.GetEntitiesBySpecForPaginationAsync(spec);

            return GetMappedCollectionForPagination<Pet, PetDTO>(petsData, parameters);
        }

        [HttpGet("animals")]
        public async Task<ActionResult<IEnumerable<AnimalDTO>>> GetAllAnimals()
        {
            IEnumerable<Animal> animals = await _animalRepository.GetEntities();

            return GetMappedCollection<Animal, AnimalDTO>(animals);
        }

        [HttpGet("pets/{id}")]
        [ProducesResponseType(typeof(PetDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<PetDTO>> GetPetByIdAsync(int id)
        {
            var spec = new PetWithBreedAndAnimalSpecification(id);
            Pet? pet = await _petRepository.GetEntityBySpecAsync(spec);
            return GetMappedObject<Pet, PetDTO>(pet);
        }

        [HttpGet("products")]
        [ProducesResponseType(typeof(Pagination<ProductDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<Pagination<ProductDTO>>> GetAllProducts(
            [FromQuery] ProductSpecificationParameters parameters
        )
        {
            var spec = new ProductsWithProductTypeAndBrandSpecification(parameters);
            DataForPagination<Product> productsData =
                await _productRepository.GetEntitiesBySpecForPaginationAsync(spec);

            return GetMappedCollectionForPagination<Product, ProductDTO>(productsData, parameters);
        }

        [HttpGet("products/{id}")]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int id)
        {
            var spec = new ProductWithProductTypeAndBrandSpecification(id);
            Product? product = await _productRepository.GetEntityBySpecAsync(spec);
            return GetMappedObject<Product, ProductDTO>(product);
        }

        // [HttpPost]
        // public async Task<ActionResult<ProductDTO>> PostProduct(
        //     [FromBody] ProductToAddDTO productToAddDTO
        // )
        // {
        //     await _productRepository.AddEntity()
        // }

        private ActionResult<TOut> GetMappedObject<TIn, TOut>(in TIn? item)
            where TIn : BaseEntity
            where TOut : BaseDTO
        {
            if (item is null)
            {
                return NotFound(new ApiResponse(404));
            }

            TOut mappedObject = _mapper.Map<TIn, TOut>(item);
            return Ok(mappedObject);
        }

        private ActionResult<Pagination<Tout>> GetMappedCollectionForPagination<Tin, Tout>(
            in DataForPagination<Tin> dataForPagination,
            in IParameters parameters
        )
            where Tin : BaseEntity
            where Tout : BaseDTO
        {
            IEnumerable<Tin>? objectList = dataForPagination.ObjectList;
            int numberOfObjects = dataForPagination.NumberOfObjectsInDB;

            if (objectList is null || objectList.Count() == 0)
            {
                return NotFound(new ApiResponse(404));
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

        private ActionResult<IEnumerable<Tout>> GetMappedCollection<Tin, Tout>(
            IEnumerable<Tin> collectionToMap
        )
            where Tin : BaseEntity
            where Tout : BaseDTO
        {
            if (collectionToMap.Count() == 0)
            {
                return NotFound(new ApiResponse(404));
            }

            IEnumerable<Tout> mappedCollection = _mapper.Map<IEnumerable<Tin>, IEnumerable<Tout>>(
                collectionToMap
            );

            return Ok(mappedCollection);
        }
    }
}
