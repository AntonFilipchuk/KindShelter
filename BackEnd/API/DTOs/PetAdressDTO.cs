using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;

namespace API.DTOs
{
    public record PetAdressDTO
    {
        public PetAdressDTO(Adress? adress)
        {
            if (adress is null)
            {
                City = null;
                Street = null;
            }
            else
            {
                City = adress.City.CityName;
                Street = adress.Street;
                HouseNumber = adress.HouseNumber;
                FlatNumber = adress.FlatNumber;
            }
        }

        public string? City { get; init; }
        public string? Street { get; init; }
        public int? HouseNumber { get; init; }
        public int? FlatNumber { get; set; }
    }
}
