using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Enitites
{
    public record Breed : BaseEntity
    {
        public required string BreedName { get; init; }
        public required IEnumerable<Pet> Pets { get; init; }

        //Navigation Properties
        public required Animals Animals { get; init; }
        public required int AnimalsId { get; init; }

        public int GetNumberOfPets()
        {
            return Pets is null ? 0 : Pets.Count();
        }
    }
}
