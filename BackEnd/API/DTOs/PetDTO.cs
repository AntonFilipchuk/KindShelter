using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;

namespace API.DTOs
{
    public record PetDTO : BaseDTO
    {
        public PetDTO(City? city, Adress? adress)
        {
            Adress = new PetAdressDTO(city, adress);
        }

        public string Name { get; init; } = string.Empty;
        public bool? HasVaccines { get; init; } = null;
        public string PictureUrl { get; init; } = string.Empty;
        public int Age { get; init; } = 1;
        public string Gender { get; init; } = string.Empty;
        public string Color { get; init; } = string.Empty;
        public string Breed { get; init; } = string.Empty;
        public string AnimalType { get; init; } = string.Empty;
        public PetAdressDTO Adress { get; private set; }
    }
}
