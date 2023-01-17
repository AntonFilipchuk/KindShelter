using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Enitites
{
    public record Breed : BaseEntity
    {
        public string BreedName { get; init; } = string.Empty;
        public IEnumerable<Pet>? Pets { get; init; }

        //Navigation Properties
        public Animals Animals { get; init; } = default!;
        public int AnimalsId { get; init; }
        //

        public int GetNumberOfPets()
        {
            return Pets is null ? 0 : Pets.Count();
        }
    }
}
