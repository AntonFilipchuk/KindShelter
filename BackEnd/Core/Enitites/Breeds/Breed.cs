using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Enitites.Breeds
{
    public record Breed : BaseEntity
    {
        public string BreedName { get; init; } = string.Empty;
        public IEnumerable<Pet>? Pets { get; init; }

        //Navigation Properties
        public Animal Animal { get; init; } = new Animal();
        public int AnimalId { get; init; }
    }
}
