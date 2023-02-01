using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ReturnObjects.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Mapper.UrlResolvers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _configuration;
        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(
            Product source,
            ProductDTO destination,
            string destMember,
            ResolutionContext context
        )
        {
            return _configuration["ApiUrl"] + source.PictureUrl;
        }
    }
}