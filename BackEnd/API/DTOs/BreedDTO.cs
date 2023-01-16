using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public record BreedDTO : BaseDTO
    {
        public string AnimalCollectionName { get; init; } = string.Empty;
        public string BreedName { get; init; } = string.Empty;
        public int NumberOfPets { get; init; }
    }
}