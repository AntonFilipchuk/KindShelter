using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites.Breeds;

namespace Core.Enitites
{
    public record Animal : BaseEntity
    {
        public string Name { get; init; } = string.Empty;
        public bool? HasVaccines { get; init; }
        public string PictureUrl { get; init; } = string.Empty;
        public int Age { get; init; }
        public string Gender { get; init; } = string.Empty;
        public string Color { get; init; } = string.Empty;

        public BreedType BreedType { get; init; }
        public int BreedTypeId { get; init; }
    }
}
