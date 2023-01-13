using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Enitites.Breeds
{
    public record BreedType : BaseEntity
    {
        public string BreedName { get; init; } = string.Empty;
        public IEnumerable<Animal> Animals { get; init; } = new List<Animal>();

        //Navigation Properties
        public Breeds BreedsCollection { get; init; }
        public int BreedsCollectionId { get; init; }
    }
}
