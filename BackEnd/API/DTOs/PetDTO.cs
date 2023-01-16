using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public record PetDTO
    {
        public PetDTO(string city, string? street, int? house, int? flatNumber)
        {
            Location = new LocationDTO()
            {
                City = city,
                Street = street,
                FlatNumber = flatNumber,
                House = house
            };
        }

        public string Name { get; init; } = string.Empty;
        public bool? HasVaccines { get; init; } = null;
        public string PictureUrl { get; init; } = string.Empty;
        public int Age { get; init; } = 1;
        public string Gender { get; init; } = string.Empty;
        public string Color { get; init; } = string.Empty;
        public string Breed { get; init; } = string.Empty;
        public string AnimalType { get; init; } = string.Empty;
        public LocationDTO Location { get; private set; }
    }
}
