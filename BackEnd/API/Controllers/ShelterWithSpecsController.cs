using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private IMapper _mapper;

        public ShelterWithSpecsController(
            IGenericRepository<Pet> petRepository,
            IGenericRepository<Product> productRepository,
            IMapper mapper
        )
        {
            _petRepository = petRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet("pets")]
        public async Task<ActionResult<Pagination<PetDTO>>> GetAllPets(
            [FromQuery] PetSpecificationParameters parameters
        )
        {
            var spec = new PetsWithLocationAndBreedSpecification(parameters);
            DataForPagination<Pet> petsData =
                await _petRepository.GetEntitiesBySpecForPaginationAsync(spec);

            return ReturnMappedCollection<Pet, PetDTO>(petsData, parameters);
        }

        [HttpGet("pets/{id}")]
        public async Task<ActionResult<PetDTO>> GetPetByIdAsync(int id)
        {
            var spec = new PetWithLocationAndBreedSpecification(id);
            Pet? pet = await _petRepository.GetEntityBySpec(spec);
            return ReturnMappedObject<Pet, PetDTO>(pet);
        }

        [HttpGet("products")]
        public async Task<ActionResult<Pagination<ProductDTO>>> GetAllProducts(
            [FromQuery] ProductSpecificationParameters parameters
        )
        {
            var spec = new ProductsWithProductTypeAndBrandSpecification(parameters);
            DataForPagination<Product> productsData =
                await _productRepository.GetEntitiesBySpecForPaginationAsync(spec);

            return ReturnMappedCollection<Product, ProductDTO>(productsData, parameters);
        }

        [HttpGet("products/{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int id)
        {
            var spec = new ProductWithProductTypeAndBrandSpecification(id);
            Product? product = await _productRepository.GetEntityBySpec(spec);
            return ReturnMappedObject<Product, ProductDTO>(product);
        }

        // [HttpPost]
        // public async Task<ActionResult<ProductDTO>> PostProduct(
        //     [FromBody] ProductToAddDTO productToAddDTO
        // )
        // {
        //     await _productRepository.AddEntity()
        // }

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
