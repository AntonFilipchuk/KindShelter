using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;

namespace API.DTOs
{
    public record PetAdressDTO
    {
        public PetAdressDTO(City? city, Adress? adress)
        {
            if (city is null)
            {
                City = null;
            }
            else
            {
                City = city.CityName;
            }

            if (adress is null)
            {
                Street = null;
            }
            else
            {
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
