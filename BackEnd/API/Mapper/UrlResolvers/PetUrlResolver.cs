using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ReturnObjects.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Mapper.UrlResolvers
{
    public class PetUrlResolver : IValueResolver<Pet, PetDTO, string>
    {
        private readonly IConfiguration _configuration;
        public PetUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(
            Pet source,
            PetDTO destination,
            string destMember,
            ResolutionContext context
        )
        {
            return _configuration["ApiUrl"] + source.PictureUrl;
        }
    }
}
