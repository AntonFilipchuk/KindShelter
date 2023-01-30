using API.ReturnObjects.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Mapper
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember
                (productDTO => productDTO.ProductType,
                options => options.MapFrom(product => product.ProductType.ProductTypeName))
                .ForMember
                (productDTO => productDTO.Brand,
                options => options.MapFrom(product => product.Brand.BrandName));
        }
    }
}
