using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;

namespace Core.Enitites
{
    public record Pet : BaseEntity
    {
        public required string Name { get; init; }
        public required string PictureUrl { get; init; }
        public required int Age { get; init; }
        public required string Gender { get; init; }
        public required string Color { get; init; }
        public bool? HasVaccines { get; init; } = false;
        public string? Description { get; init; }

        public required Adress Adress { get; init; }
        public required int? AdressId { get; init; }

        //Navigation properties
        public required Breed Breed { get; init; }
        public required int BreedId { get; init; }
    }
}
