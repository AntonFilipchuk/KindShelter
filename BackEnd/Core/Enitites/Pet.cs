using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;

namespace Core.Enitites
{
    public record Pet : BaseEntity
    {
        public string Name { get; init; } = string.Empty;
        public string PictureUrl { get; init; } = string.Empty;
        public int Age { get; init; } = 1;
        public string Gender { get; init; } = string.Empty;
        public string Color { get; init; } = string.Empty;
        public bool? HasVaccines { get; init; } = false;
        public string? Description { get; init; } = string.Empty;

        public City? City { get; init; }
        public int? CityId { get; init; }
        public Adress? Adress { get; init; }
        public int? AdressId { get; init; }

        //Navigation properties
        public Breed Breed { get; init; } = default!;
        public int BreedId { get; init; }
    }
}
